using System;
using Microsoft.EntityFrameworkCore;

namespace auth_project.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope(); 
        var dbContext = scope.ServiceProvider.GetRequiredService<AuthContext>();
        dbContext.Database.Migrate();
        // apdate Program.cs to add it 
    }
}
