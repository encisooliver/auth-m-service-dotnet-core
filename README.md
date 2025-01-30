# auth-m-service-dotnet-core

Download VS Code
Install extension 
C# Dev Kit
C# (Base language support for C#)
.NET Install Tool
IntelliCodee for C#
Rest Client
sqlite

To install the .NET SDK 8.0 on Ubuntu, follow these steps:
1. Remove Previous Versions (Optional but Recommended)

If you have older versions of the .NET SDK installed, remove them first to avoid conflicts:

sudo apt remove --purge dotnet-sdk-* aspnetcore-* dotnet-* 
sudo apt autoremove

2. Install Required Dependencies

Ensure you have the necessary dependencies for the installation:

sudo apt update
sudo apt install -y apt-transport-https ca-certificates

3. Add Microsoft’s Package Repository

Add the Microsoft package signing key and repository:

wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

4. Update the Package Index

After adding the repository, update the package list:

sudo apt update

5. Install .NET SDK 8.0

Install the .NET SDK version 8.0:

sudo apt install -y dotnet-sdk-8.0

6. Verify Installation

Check the installed SDK to confirm that .NET SDK 8.0 is installed correctly:

dotnet --list-sdks
8.0.405 [/usr/share/dotnet/sdk]

dotnet --info


dotnet --version
dotnet --info
dotnet new list (show project templates)

Build project
Go to solution explorer

1. Right click > build
> Assembly of compiled version of the application located
/home/oliver/Documents/2025/dotnet/projects/auth-project/bin/Debug/net8.0/auth-project.dll

2. Command line 
dotnet build

3. Ctrl + Shift + B
dotnet: build

Run application
1. Right click to solution explorer and select debug or start without debugging
2. dotnet run

Manual testing Endpoints
Add auth.http file to root directory
Add line
GET http://localhost:5118
Sent Request

Prevent application to launch in browser
 Set launchBrowser false
 > Properties update launchSettings.json
"profiles": {
    "http": {
      ...
      "launchBrowser": true, 
      ...
      }
    },
    "https": {
       ...
      "launchBrowser": true, 
      ...
    },
    
 
 Add DTOs folder in you project
 1. Go to solution explorer
 2. Right click and add new folder
 
 Parameter Validation
 Nuget Package
 MinimalApis.Extensions
 dotnet add package MinimalApis.Extensions --version 0.11.0
 dotnet remove package MinimalApis.Extensions
 
 Entity Framework Core
 A lightweight, extensible, open source and cross-platform object-relational mapper for .NET
 Benefits
 - no need to learn new language
 - minimal data-access code (LINQ)
 - change tracking
 - multiple database providers
 
 SQLite
 dotnet add package Microsoft.EntityFrameworkCore.Sqlite
 
dotnet-ef - manage Migrations and to scaffold a DbContext and entity types by reverse engineering the schema of a database
 dotnet tool install --global dotnet-ef --version 9.0.1
 
 Microsoft.EntityFrameworkCore.Design 
 manage Migrations and to scaffold a DbContext and entity types by reverse engineering the schema of a database.
 
 dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.1
 
 Create migration 
 dotnet ef migrations add IntitialCreate --output-dir Data/Migrations
 
Install SQLite 3 on Ubuntu 22.04 
sudo apt update
sudo apt upgrade
sudo apt install sqlite3
sqlite3 --version
sqlite3







