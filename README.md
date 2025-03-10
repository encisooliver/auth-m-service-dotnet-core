# auth-m-service-dotnet-core

## Summary
1. Environment Setup
2. Select design pattern to use
3. Setup ORM - Entity Framework
4. Setup DbContext
5. Setup JWT authentication and authorization
6. Setup global exception handler
7. Add swagger
8. Add unit test
 
### Environment Setup
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


### Project Setup
dotnet --version
dotnet --info
dotnet new list (show project templates)

Build project
Go to solution explorer

1. Create new project
dotnet new webapi -o project-name

2. Command line 
dotnet build

Or
Right click > build
> Assembly of compiled version of the application located
/home/oliver/Documents/2025/dotnet/projects/auth-project/bin/Debug/net8.0/auth-project.dll

Or
Ctrl + Shift + B
dotnet: build

3. Run application
1. Right click to solution explorer and select debug or start without debugging
2. dotnet run

4. Manual testing Endpoints
Add/create new file auth.http to root directory
Add line
GET http://localhost:5118
Sent Request

### Environment configuration
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
    

### Add DTOs folder in you project
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
 
Add SQLite
 dotnet add package Microsoft.EntityFrameworkCore.Sqlite

Add new folder Data and add AuthContext
  > Data
      AuthContext.cs
  
Add db context to Programs.cs
  var connectionString = builder.Configuration.GetConnectionString("AuthStore");
  builder.Services.AddSqlite<AuthContext>(connectionString);  

  IConfiguration
    appsettings.json - Never store credentials in this file
    Command Line Args
    Environment Variables
    User Secrets - Use this if connections strings includes secrets
    Cloud Source

### Setup ORM
1. dotnet-ef - manage Migrations and to scaffold a DbContext and entity types by reverse engineering the schema of a database 
 dotnet tool install --global dotnet-ef --version 9.0.1
 
2. Microsoft.EntityFrameworkCore.Design 
   manage Migrations and to scaffold a DbContext and entity types by reverse engineering the schema of a database.
  
   dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.1
 
3. Create migration based on defined Entities
    dotnet ef migrations add IntitialCreate --output-dir Data/Migrations

4. Execute migration 
    dotnet ef database update

5. Implement auto run migration
    DataExtensios.cs

6. Add seeder in AuthContext.cs
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserTypeModel>().HasData(
            new { Id = 1, Type = "Admin"},
            new { Id = 2, Type = "User"}
        );
    }

    Run migration
      dotnet ef migrations add SeedUserTypes --output-dir Data/Migration
    Revert migration
      dotnet ef migrations remove
  
  Update table column remove foreignkey column
    
    sqlite3 yourdatabase.db "DELETE FROM __EFMigrationsHistory WHERE MigrationId = '20250201025908_SeederUser';"
    sqlite3 yourdatabase.db"DELETE FROM __EFMigrationsHistory WHERE MigrationId = '20250201025908_SeederUser';"
 
Install SQLite 3 on Ubuntu 22.04 
sudo apt update
sudo apt upgrade
sudo apt install sqlite3
sqlite3 --version
sqlite3


### Dependency Injection
It refers to an external library, module, or component that a project relies on to function properly. 

Abstraction
Interface
Singleton Service Lifetime


### Add swagger
Run:
dotnet add package Swashbuckle.AspNetCore

Update Program.cs
builder.Services.AddSwaggerGen();
...
app.UseSwagger();
app.UseSwaggerUI();

### Global exception handler
Source: https://www.milanjovanovic.tech/blog/global-error-handling-in-aspnetcore-8

Xunit Test Dependencies
dotnet add package xunit
dotnet add package moq
dotnet add package Microsoft.AspNetCore.Mvc.Core
dotnet add package Microsoft.AspNetCore.Mvc.Abstractions
dotnet add package BCrypt.Net-Next // password hashing




