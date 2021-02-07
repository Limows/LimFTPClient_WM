using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

/*	
FTP Command set:
 
Note that commands marked with a * are not implemented in a number of FTP servers. 


Common commands
ABOR - abort a file transfer 
CWD - change working directory 
DELE - delete a remote file 
LIST - list remote files 
MDTM - return the modification time of a file 
MKD - make a remote directory 
NLST - name list of remote directory 
PASS - send password 
PASV - enter passive mode 
PORT - open a data port 
PWD - print working directory 
QUIT - terminate the connection 
RETR - retrieve a remote file 
RMD - remove a remote directory 
RNFR - rename from 
RNTO - rename to 
SITE - site-specific commands 
SIZE* - return the size of a file 
STOR - store a file on the remote host 
TYPE - set transfer type 
USER - send username 
Less common commandsACCT* - send account information 
APPE - append to a remote file 
CDUP - CWD to the parent of the current directory 
HELP - return help on using the server 
MODE - set transfer mode 
NOOP - do nothing 
REIN* - reinitialize the connection 
STAT - return server status 
STOU - store a file uniquely 
STRU - set file transfer structure 
SYST - return system type 
*/

namespace NetCFLibFTP
{
	/// <summary>
	/// This class can be used for FTP operations
	/// </summary>
	public class FTP
	{
        /// <summary>
        /// Handler for FTP responses
        /// </summary>
        public delegate void FTPResponseHandler(FTP source, FTPResponse Response);
        /// <summary>
        /// Handler for FTP commands
        /// </summary>
        public delegate void FTPCommandHandler(FTP source, string CommandSent);
        /// <summary>
        /// Handler for FTP connections
        /// </summary>
        public delegate void FTPConnectedHandler(FTP source);

        /// <summary>
        /// FTP Mode
        /// </summary>
        internal enum FTPMode
        {
            Passive = 0,
            Active = 1
        }

        /// <summary>
        /// FTP Transfer type
        /// </summary>
        public enum FTPTransferType
        {
            /// <summary>
            /// Binary Transfer
            /// </summary>
            Binary = 0,
            /// <summary>
            /// ASCII Transfer
            /// </summary>
            ASCII = 1
        }

        /// <summary>
        /// Detected FTP Server type
        /// </summary>
        public enum FTPServerType
        {
            /// <summary>
            /// Unix-compliant server
            /// </summary>
            Unix = 0,
            /// <summary>
            /// Windows/IIS-compliant server
            /// </summary>
            Windows = 1,
            /// <summary>
            /// Unknown server type
            /// </summary>
            Unknown = 2
        }

        /// <summary>
        /// Information returned in a response from an FTP command
        /// <seealso cref="FTP.ReadResponse()"/>
        /// </summary>
        public struct FTPResponse
        {
            /// <summary>
            /// Response ID value
            /// </summary>
            public StatusCode ID;
            /// <summary>
            /// Response text
            /// </summary>
            public string Text;
        }

        /// <summary>
        /// FTP File Type
        /// </summary>
        public enum FTPFileType
        {
            /// <summary>
            /// A file
            /// </summary>
            File = 0,
            /// <summary>
            /// A directory
            /// </summary>
            Directory = 1
        }

        public enum StatusCode
        {
            RestartMarkerReply = 110,
            ServiceReadyInNMinutes = 120,
            ConnectionAlreadyOpen = 125,
            FileStatusOK = 150,

            CommandOkay = 200,
            CommandNotImplemented = 202,
            SystemStatus = 211,
            DirectoryStatus = 212,
            FileStatus = 213,
            HelpMessage = 214,
            SystemType = 215,
            ServiceReady = 220,
            ControlConnectionClosed = 221,
            ConnectionOpen = 225,
            ClosingConnection = 226,
            EnteringPassiveMode = 227,
            LoginSuccess = 230,
            FileActionComplete = 250,
            PathCreated = 257,

            NameAccepted = 331,
            NameRequired = 332,
            FileActionPendingInfo = 350,

            FileNotFound = 550
        }

		private static int BUFFER_SIZE = 1024;
        private static int DEFAULT_PORT = 21;

		private bool				m_connected		= false;
		private FTPMode				m_mode			= FTPMode.Passive;
        private int m_port = DEFAULT_PORT;
		private string				m_host			= "";
		private FTPTransferType		m_type			= FTPTransferType.Binary;
		private string				m_uid			= "";
		private string				m_pwd			= "";
		private Socket				m_cmdsocket		= null;
		private bool				m_exceptions	= true;
		private byte[]				m_buffer		= new byte[BUFFER_SIZE];
		private FTPServerType		m_server		= FTPServerType.Unknown;
		private int					m_timeout		= 5000;
        private FTPResponse         m_response      = new FTPResponse();
        private Stream              m_data          = null;

		/// <summary>
		/// Event raised when the FTP server sends a response
		/// </summary>
		public event FTPResponseHandler ResponseReceived;
		/// <summary>
		/// Event raised when a command is sent to the FTP server
		/// </summary>
		public event FTPCommandHandler  CommandSent;

		#region ctors / dtor
		/// <summary>
		/// Creates an FTP object
		/// </summary>
		public FTP()
		{
		}

		/// <summary>
		/// Creates an FTP object
		/// </summary>
		/// <param name="remoteHost">Hostname that will be connected to.  The port will default to 21.</param>
		public FTP(string remoteHost)
            : this(remoteHost, DEFAULT_PORT)
		{
		}

		/// <summary>
		/// Creates an FTP object
		/// </summary>
		/// <param name="remoteHost">Hostname that will be connected to.</param>
		/// <param name="port">Port on which to connect</param>
		public FTP(string remoteHost, int port)
		{
			m_host = remoteHost;
			m_port = port;
		}
		#endregion

		#region methods
		/// <summary>
		/// When set, if an error is encountered while using the class instance, an exception will be thrown
		/// </summary>
		public bool ExceptionOnError
		{
			set
			{
				m_exceptions = value;
			}
			get
			{
				return m_exceptions;
			}
		}

        private void EndConnection(IAsyncResult state)
        {
            try
            {
                Socket socket = (Socket)state.AsyncState;

                if (socket != null)
                {
                    socket.EndConnect(state);
                }
            }
            catch
            {

            }
            finally
            {
                FTPParameters.EndConnectEvent.Set();
            }
        }

		/// <summary>
		/// Connect to the FTP server using the supplied username and password
		/// </summary>
		/// <param name="username">Username</param>
		/// <param name="password">Password</param>
		public void Connect(string username, string password)
		{
			m_uid = username;
			m_pwd = password;

			if(m_connected)
			{
				throw new FTPException("Already Connected");
			}

			try
			{
                IPEndPoint endpoint;
                FTPResponse response;

                m_cmdsocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);

                try
                {
                    IPAddress address = IPAddress.Parse(m_host);
                    endpoint = new IPEndPoint(address, m_port);
                }
                catch (System.FormatException)
                {
                    try
                    {
                        IPAddress address = Dns.GetHostEntry(m_host).AddressList[0];
                        endpoint = new IPEndPoint(address, m_port);
                    }
                    catch (SocketException)
                    {
                        m_cmdsocket = null;
                        m_connected = false;
                        return;
                    }
                }

                // make the connection
                FTPParameters.EndConnectEvent = new AutoResetEvent(false);
                m_cmdsocket.BeginConnect(endpoint, EndConnection, m_cmdsocket);
                FTPParameters.EndConnectEvent.WaitOne(m_timeout, false);

                if (!m_cmdsocket.Connected)
                {
                    m_cmdsocket.Close();
                    return;
                }

                // check the result
                ReadResponse();

                if (m_response.ID != StatusCode.ServiceReady)
                {
                    m_cmdsocket.Close();
                    m_cmdsocket = null;

                    if (!m_exceptions)
                    {
                        return;
                    }
                    else
                    {
                        m_connected = false;
                        return;
                    }
                }

                // set the user id
                response = SendCommand("USER " + m_uid, false);

                // check the response
                if (!((response.ID == StatusCode.NameAccepted) || (response.ID == StatusCode.LoginSuccess)))
                {
                    m_cmdsocket.Close();
                    m_cmdsocket = null;
                    Disconnect();

                    if (!m_exceptions)
                    {
                        return;
                    }
                    else
                    {
                        m_connected = false;
                        return;
                    }
                }

                // if a PWD is required, send it
                if (response.ID == StatusCode.NameAccepted)
                {
                    response = SendCommand("PASS " + m_pwd, false);
                    if (!((response.ID == StatusCode.CommandNotImplemented) || (response.ID == StatusCode.LoginSuccess)))
                    {
                        m_cmdsocket.Close();
                        m_cmdsocket = null;
                        Disconnect();
                        m_connected = false;
                        return;
                    }
                }

                m_server = FTPServerType.Unix;
                m_connected = true;

            }
			catch(Exception ex)
			{
                System.Diagnostics.Debug.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// Disconnect from the FTP server
		/// </summary>
		public void Disconnect()
		{
			if(m_cmdsocket != null)
			{
				FTPResponse response = SendCommand("QUIT");
				m_cmdsocket.Close();
				m_cmdsocket = null;
			}
			
			m_server	= FTPServerType.Unknown;
			m_connected = false;
		
		}

		/// <summary>
		/// Retrieves a file from the FTP server
		/// </summary>
		/// <param name="remoteFileName">Name of the file to get</param>
		/// <param name="localFileName">Local name under which to save the retrieved file</param>
		/// <param name="overwrite">Overwrite the local file if it already exists</param>
        public void GetFile(string remoteFileName, string localFileName, bool overwrite)
        {
            FTPResponse response;

            using (m_data = File.Create(localFileName))
            {
                using (Socket m_datasocket = OpenDataSocket())
                {
                    response = SendCommand("RETR " + remoteFileName);

                    if (!((response.ID == StatusCode.FileStatusOK) || (response.ID == StatusCode.ConnectionAlreadyOpen)))
                    {
                        if (!m_exceptions)
                        {
                            return;
                        }
                        else
                        {
                            throw new FTPException(response.ID.ToString());
                        }
                    }

                    /*

                    // get the data
                    while (true)
                    {
                        bytesrecvd = m_datasocket.Receive(m_buffer, m_buffer.Length, 0);
                        output.Write(m_buffer, 0, bytesrecvd);

                        if (bytesrecvd <= 0)
                        {
                            break;
                        }
                    }
                     */

                    FTPParameters.EndResponseEvent = new AutoResetEvent(false);
                    m_datasocket.BeginReceive(m_buffer, 0, m_buffer.Length, 0, EndDataResponse, m_datasocket);
                    FTPParameters.EndResponseEvent.WaitOne();
                }

                ReadResponse();

                response = m_response;

                if (response.ID == 0)
                {
                    return;
                }

                if (!((response.ID == StatusCode.ClosingConnection) || (response.ID == StatusCode.FileActionComplete)))
                {
                    if (!m_exceptions)
                    {
                        return;
                    }
                    else
                    {
                        throw new FTPException(response.ID.ToString());
                    }
                }
            }
        }

		/// <summary>
		/// Retrieves the filelist string as the FTP server sends it
		/// <seealso cref="EnumFiles"/>
		/// </summary>
		/// <param name="Detailed">When set file sizes and dates are also retrieved (LIST)</param>
		/// <returns>The server file list as a string</returns>
		public string GetFileList(bool Detailed)
		{
			FTPResponse		response;
            StringBuilder dirInfo = new StringBuilder(BUFFER_SIZE);

            using (Socket m_datasocket = OpenDataSocket())
            {
                if (Detailed)
                {
                    response = SendCommand("LIST");
                }
                else
                {
                    response = SendCommand("NLST");
                }

                if (!((response.ID == StatusCode.FileStatusOK) || (response.ID == StatusCode.ConnectionAlreadyOpen)))
                {
                    if (!m_exceptions)
                    {
                        return "";
                    }
                    else
                    {
                        throw new IOException(response.Text);
                    }
                }

                using(m_data = new MemoryStream())
                {
                    FTPParameters.EndResponseEvent = new AutoResetEvent(false);
                    m_datasocket.BeginReceive(m_buffer, 0, m_buffer.Length, 0, EndDataResponse, m_datasocket);
                    FTPParameters.EndResponseEvent.WaitOne(m_timeout, false);

                    using (BinaryReader Reader = new BinaryReader(m_data))
                    {
                        m_data.Position = 0;

                        int count = Reader.Read(m_buffer, 0, m_buffer.Length);

                        while (count > 0)
                        {
                            dirInfo.Append(Encoding.ASCII.GetString(m_buffer, 0, count));
                            count = Reader.Read(m_buffer, 0, m_buffer.Length);
                        }
                    }
                }            
            }
			return dirInfo.ToString();
		}

        /// <summary>
        /// Get a size of current file
        /// </summary>
        /// <param name="remoteFileName">Name of the file to get</param>
        /// <returns>String with file size</returns>
        public string GetFileSize(string remoteFileName)
        {
            FTPResponse response = SendCommand("SIZE " + remoteFileName);

            if (!(response.ID == StatusCode.FileStatus))
            {
                if (!m_exceptions)
                {
                    return "";
                }
                else
                {
                    throw new IOException(response.Text);
                }
            }

            return response.Text;
        }

		/// <summary>
		/// Change the remote working directory
		/// </summary>
		/// <param name="directory">Name of directory to use</param>
		public void ChangeDirectory(string directory)
		{
			FTPResponse response;

			// make sure we're connected

			response = SendCommand("CWD " + directory);

            if (response.ID != StatusCode.FileActionComplete)
			{
				if(!m_exceptions)
				{
					return;
				}
				else
				{
					throw new FTPException(response.Text);
				}
			}
		}

		private FTPResponse SendCommand(string command, bool checkConnection)
		{
			// make sure we're connected
			if(checkConnection)
				CheckConnect();

			// encode the command
			byte[] bytes = Encoding.ASCII.GetBytes((command + "\r\n").ToCharArray());

			// send it
			m_cmdsocket.Send(bytes, bytes.Length, 0);

			if(CommandSent != null)
			{
				foreach(FTPCommandHandler ch in CommandSent.GetInvocationList())
				{
					ch(this, command);
				}
			}

            ReadResponse();

            return m_response;
		}

		/// <summary>
		/// Send a generic or server-specific command to the FTP server
		/// <seealso cref="FTPResponse"/>
		/// </summary>
		/// <param name="command">Command to send</param>
		/// <returns>The server's response to the command</returns>
		public FTPResponse SendCommand(string command)
		{
			return SendCommand(command, true);
		}

        private void ReadResponse()
        {
            FTPParameters.EndResponseEvent = new AutoResetEvent(false);
            m_cmdsocket.BeginReceive(m_buffer, 0, m_buffer.Length, 0, EndCommandResponse, m_cmdsocket);
            FTPParameters.EndResponseEvent.WaitOne(m_timeout, false);
        }

        private void EndCommandResponse(IAsyncResult state)
		{   
            FTPResponse response = new FTPResponse();
            string responsetext = "";
            int recievedBytes = 0;

            try
            {   
                recievedBytes = m_cmdsocket.EndReceive(state);
            }
            catch
            {
                FTPParameters.EndResponseEvent.Set();
                return;
            }

            responsetext += Encoding.ASCII.GetString(m_buffer, 0, recievedBytes);

            if (String.IsNullOrEmpty(responsetext))
            {
                response.ID = 0;
                response.Text = "";
                m_response = response;
                FTPParameters.EndResponseEvent.Set();
                return;
            }

            string[] message = responsetext.Replace("\r", "").Split('\n');

            // we may have multiple responses, 
            // particularly if retriving small amounts of data like directory listings
            // such as the command sent and transfer complete together
            // a response may also have multiple lines
            for (int m = 0; m < message.Length; m++)
            {
                try
                {
                    // is the first line a response?  If so, the first 3 characters
                    // are the response ID number
                    FTPResponse resp = new FTPResponse();

                    if (message[m].Length > 0)
                    {
                        try
                        {
                            resp.ID = (StatusCode)int.Parse(message[m].Substring(0, 3));
                        }
                        catch (Exception)
                        {
                            resp.ID = 0;
                        }

                        resp.Text = message[m].Substring(4);

                        if (ResponseReceived != null)
                        {
                            foreach (FTPResponseHandler rh in ResponseReceived.GetInvocationList())
                            {
                                try
                                {
                                    rh(this, resp);
                                }
                                catch(Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(string.Format("FTPResponseHandler threw {0}\r\n{1}", ex.GetType().Name, ex.Message));
                                    // if any event handler fails, we ignore it
                                }
                            }
                        }

                        if (m == 0)
                        {
                            response = resp;
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
    
                m_response = response;
                FTPParameters.EndResponseEvent.Set();
                return;
            }

            // return the first response received
            m_response = response;
            FTPParameters.EndResponseEvent.Set();
            return;
		}

        private void EndDataResponse(IAsyncResult state)
        {
            int recievedBytes = 0;
            Socket socket = (Socket)state.AsyncState;
            BinaryWriter Writer = new BinaryWriter(m_data);

                try
                {
                    recievedBytes = socket.EndReceive(state);
                    Writer.Write(m_buffer, 0, recievedBytes);
                    Writer.Flush();
                    //m_data.Write(m_buffer, 0, recievedBytes);
                    //dirInfo.Append(Encoding.ASCII.GetString(m_buffer, 0, recievedBytes));
                }
                catch
                {
                    FTPParameters.EndResponseEvent.Set();
                    Writer.Flush();
                    return;
                }

                if (recievedBytes > 0)
                {
                    socket.BeginReceive(m_buffer, 0, m_buffer.Length, 0, EndDataResponse, socket);
                }
                else
                {
                    FTPParameters.EndResponseEvent.Set();
                    Writer.Flush();
                }
        }

		private void CheckConnect()
		{
			if(! m_connected)
			{
				throw new FTPException("Method only valid with an open connection");
			}
		}

		private Socket OpenDataSocket()
		{
			FTPResponse response;
			int			port;
			string		ipAddress;

			if(m_mode == FTPMode.Passive)
			{
				response = SendCommand("PASV");

                if (response.ID != StatusCode.EnteringPassiveMode)
				{
					throw new FTPException(response.Text);
				}

				// get the remote server's IP address
				int start = response.Text.IndexOf('(');
				int end = response.Text.IndexOf(')');

				string ipstring = response.Text.Substring(start + 1, end - start - 1);
				int[] parts = new int[6];

				int part = 0;
				string buffer="";

				for (int i = 0 ;(i < ipstring.Length) && (part <= 6); i++)
				{
					char ch = ipstring[i];
					if (char.IsDigit(ch))
					{
						buffer += ch;
					}

					else if(ch != ',')
					{
						throw new FTPException("Malformed PASV reply: " + response.Text);
					}

					if( (ch == ',') || (i + 1 == ipstring.Length) )
					{

						try
						{
							parts[part++] = int.Parse(buffer);
							buffer="";
						}
						catch (Exception)
						{
							throw new FTPException("Malformed PASV reply: " + response.Text);
						}
					}
				} // for (int i = 0 ;(i < ipstring.Length) && (part <= 6); i++)

				ipAddress = parts[0] + "."+ parts[1]+ "." +
					parts[2] + "." + parts[3];

				port = (parts[4] << 8) + parts[5];
			}
			else
			{
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());

				long ip = ipHost.AddressList[0].Address;

				string dotip = (ip & 0xFF) + ", " 
					+ ((ip & (0xFF << 8)) >> 8) + ", "
					+ ((ip & (0xFF << 16)) >> 16) + ", "
					+ ((ip & (0xFF << 24)) >> 24);
				
				dotip += (", " + (m_port & (0xFF << 8)));
				dotip += (", " + (m_port & 0xFF));

				response = SendCommand("PORT " + dotip);

                if (response.ID != StatusCode.CommandOkay)
				{
					throw new FTPException(response.Text);
				}
				
				ipAddress = m_host;
				port = m_port;
			}

			Socket socket = new Socket(AddressFamily.InterNetwork, 
				SocketType.Stream,
				ProtocolType.Tcp);

            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);

            FTPParameters.EndConnectEvent = new AutoResetEvent(false);
            socket.BeginConnect(endpoint, EndConnection, socket);
            FTPParameters.EndConnectEvent.WaitOne(m_timeout, false);

            if (!socket.Connected)
            {
                socket.Close();
                throw new FTPException("Can't connect to remote server");
            }

			return socket;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Sets the size of the internal buffer used for FTP transfers.  Default is 512 bytes
		/// </summary>
		public int BufferSize
		{
			get 
			{ 
				return m_buffer.Length; 
			}
			set 
			{ 
				m_buffer = new byte[value]; 
			}
		}

		/// <summary>
		/// The remote server type
		/// </summary>
		public FTPServerType ServerType
		{
			get
			{
				return m_server;
			}
		}

		/// <summary>
		/// Gets the current connection state
		/// </summary>
		public bool IsConnected
		{
			get
			{
				return m_connected;
			}
		}

		/// <summary>
		/// The port on which to connect
		/// </summary>
		public int Port
		{
			get
			{
				return m_port;
			}
			set
			{
				if(m_connected)
				{
					throw new FTPException("Cannot change port while connected");
				}

				m_port = value;
			}
		}

		/// <summary>
		/// The connection's remot host
		/// </summary>
		public string RemoteHost
		{
			get
			{
				return m_host;
			}
			set
			{
				if(m_connected)
				{
					throw new FTPException("Cannot change host while connected");
				}

				m_host = value;
			}
		}

		/// <summary>
		/// The remote directory
		/// </summary>
		public string RemoteDirectory
		{
			get
			{
				string	dir = "";
				int		pos	= 0;

				if(!m_connected)
				{
					throw new FTPException("Cannot get remote directory without an open connection");
				}

				FTPResponse response = SendCommand("PWD");

				dir = response.Text;
				pos = dir.IndexOf("\"") + 1;
				dir = dir.Substring(pos);
				pos = dir.IndexOf("\"");
				dir = dir.Substring(0, pos);

				return dir;
			}
			set
			{
				if(value == "")
				{
					value = "\\";
				}

				if(m_connected)
				{
					FTPResponse response;

					response = SendCommand("CWD " + value);

                    if (response.ID != StatusCode.FileActionComplete)
					{
						if(!m_exceptions)
						{
							return;
						}
						else
						{
							throw new FTPException(response.Text);
						}
					}
				}
			}
		}

		/// <summary>
		/// The username used to make the connection
		/// </summary>
		public string Username
		{
			get
			{
				return m_uid;
			}
		}

		/// <summary>
		/// Timeout for FTP operations
		/// </summary>
		public int ConnectionTimeout
		{
			get
			{
				return m_timeout;
			}
			set
			{
				if(value <= 0)
				{
					throw new ArgumentOutOfRangeException("Timeout must be > 0");
				}

				m_timeout = value;
			}
		}
		
		/// <summary>
		/// The transfer type
		/// <seealso cref="FTPTransferType"/>
		/// </summary>
		public FTPTransferType TransferType
		{
			get
			{
				return m_type;
			}
			set
			{
				FTPResponse response;
				m_type = value;

				if(m_type == FTPTransferType.Binary)
				{
					response = SendCommand("TYPE I");
				}
				else
				{
					response = SendCommand("TYPE A");
				}

                if (response.ID != StatusCode.CommandOkay)
				{
					if(!m_exceptions)
					{
						return;
					}
					else
					{
						throw new FTPException(response.Text);
					}
				}
			}
		}

		#endregion Properties
	}
}
