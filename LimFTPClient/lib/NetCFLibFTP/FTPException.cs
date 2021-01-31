using System;

namespace NetCFLibFTP
{
	/// <summary>
	/// Exception raised by methods in the FTP class
	/// <seealso cref="FTP"/>
	/// </summary>
	public class FTPException : Exception
	{
		public FTPException(string message) : base(message)
		{
		}

		public FTPException(string message, Exception ex) : base(message, ex)
		{
		}
	}
}
