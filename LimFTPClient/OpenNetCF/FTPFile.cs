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
	/// Information about an FTP File
	/// <seealso cref="FTP.EnumFiles"/>
	/// </summary>
	public class FTPFile
	{
		private string		m_name;
		private int			m_size;
		private FTPFileType m_type;
		private DateTime	m_date;

		internal FTPFile(string name, FTPFileType type, int size, DateTime date)
		{
			m_name = name;
			m_size = size;
			m_type = type;
			m_date = date;

		}

		/// <summary>
		/// Filename
		/// </summary>
		public string Name
		{
			get
			{
				return m_name;
			}
		}

		/// <summary>
		/// File date
		/// </summary>
		public DateTime FileDate
		{
			get
			{
				return m_date;
			}
		}

		/// <summary>
		/// File size
		/// </summary>
		public int Size
		{
			get
			{
				return m_size;
			}
		}

		/// <summary>
		/// File type
		/// <seealso cref="FTPFileType"/>
		/// </summary>
		public FTPFileType Type
		{
			get
			{
				return m_type;
			}
		}
	}
}
