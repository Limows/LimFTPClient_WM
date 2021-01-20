/*=======================================================================================
    OpenNETCF.Net.FTP
    Copyright (c) 2006-2010 OpenNETCF Consulting, LLC

    Permission is hereby granted, free of charge, to any person obtaining a copy of this 
    software and associated documentation files (the "Software"), to deal in the Software 
    without restriction, including without limitation the rights to use, copy, modify, 
    merge, publish, distribute, sublicense, and/or sell copies of the Software, and to 
    permit persons to whom the Software is furnished to do so, subject to the following 
    conditions:

    The above copyright notice and this permission notice shall be included in all copies 
    or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
    INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
    PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
    HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
    OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
    SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
=======================================================================================*/
using System;

namespace OpenNETCF.Net.Ftp
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

	internal enum FTPMode
	{
		Passive = 0,
		Active	= 1
	}

	/// <summary>
	/// FTP Transfer type
	/// </summary>
	public enum FTPTransferType
	{
		/// <summary>
		/// Binary Transfer
		/// </summary>
		Binary	= 0,
		/// <summary>
		/// ASCII Transfer
		/// </summary>
		ASCII	= 1
	}

	/// <summary>
	/// Detected FTP Server type
	/// </summary>
	public enum FTPServerType
	{
		/// <summary>
		/// Unix-compliant server
		/// </summary>
		Unix	= 0,
		/// <summary>
		/// Windows/IIS-compliant server
		/// </summary>
		Windows	= 1,
		/// <summary>
		/// Unknown server type
		/// </summary>
		Unknown	= 2
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
		File		= 0,
		/// <summary>
		/// A directory
		/// </summary>
		Directory	= 1
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
        FileActionPendingInfo = 350
    }
}
