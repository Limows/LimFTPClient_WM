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
using System.Collections;

namespace OpenNETCF.Net.Ftp
{
	/// <summary>
	/// This class encapsulates a list of files retrieves from an FTP server
	/// <seealso cref="FTP.EnumFiles"/>
	/// </summary>
	public class FTPFiles : CollectionBase
	{
		internal FTPFiles()
		{
		}

		internal void Add(FTPFile fileInfo)
		{
			List.Add(fileInfo);
		}

		/// <summary>
		/// Returns a FTPFile at a specific location in the FTPFiles
		/// <seealso cref="FTPFile"/>
		/// </summary>
		public FTPFile this[int index]
		{
			get
			{
				return (FTPFile)List[index];
			}
		}

		/// <summary>
		/// Determines whether the current FTPFiles contains the specified FTPFile
		/// <seealso cref="FTPFile"/>
		/// </summary>
		/// <param name="fileInfo"></param>
		/// <returns></returns>
		public bool Contains(FTPFile fileInfo)
		{
			return InnerList.Contains(fileInfo);
		}
		
	}
}
