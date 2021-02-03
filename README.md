# Limowski App Manager

Small Application Manager for legacy devices (Windows Mobile version) written in C# with NetCF 3.5

## Assembly

You need the following stuff to build this program:

 - Visual Studio 2005/2008
 - Windows Mobile SDK
 - ICSharpCode.SharpZipLib
 
## Installation

You need the following stuff to install this program:

 - Microsoft .Net Compact Framework 3.5

## Usage

### Choosing app for install

 Click on the application name in the list
 
### Downloading app installation

 Click on the "Download" button and after downloading choose whether to install the application
 
### Deleting installed app

### Update manager

 Click the update menu item. 
 After verification, the manager will offer to download the new version, if it exists.
 After downloading, close the program and run the file "Update.cab" from your Downloading directory

## Supported functions

 - Listing available for device applications
 - App page contains description and logo
 - Downloading app package
 - Unpacking and installing package
 - Listing installed on device applications
 - Watching application properties
 - Uninstalling application
 - Displaying free space in the installation folder
 
## OS Support

 - Windows Mobile 2003
 - Windows Mobile 5
 - Windows Mobile 6
 - Windows Mobile 6.1
 - Windows Mobile 6.5
 
## Used projects

 - OpenNetCF.Net.FTP library
 - ICSharpCode.SharpZipLib library

## Tested devices

 - HTC Cruise
 - HP iPaq H2200
 - Asus MyPal A639
 - Dell Axim x51v

## Contributing

Bug reports and pull requests are welcome on GitHub at https://github.com/Limows/LimowsFTPClient_WM.

## License

This project is licensed under the terms of the [2-Clause BSD License](https://opensource.org/licenses/BSD-2-Clause).
