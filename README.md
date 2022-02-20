# Host a Blazor Server as a Windows Service
Demo project to hosting a Blazor Server as a Windows Service

## Tools
* Visual Studio 2022
* [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0) for v6.x.x
* NSSM - the Non-Sucking Service Manager
  - [NSSM](https://nssm.cc) 
  - [Source](https://git.nssm.cc/nssm/nssm)
  - Licence : NSSM is public domain. You may unconditionally use it and/or its source code for any purpose you wish.

## Build and Run
* Build solutions
* Publish project [optional]
* In deploy folder copy all file from ***Tools*** folder

## Then run as administrator
| Batch file  | Description |
| ----------- | ----------- |
| InstallService.bat   | Install service   |
| UninstallService.bat | Uninstall service |
| StartService.bat     | Start service     |
| StopService.bat      | Stop service      |



## Note
Service is installed in ***manual start*** so you need start it !

## Code Reviewers and Contributors
[@andreatosato](https://github.com/andreatosato)
