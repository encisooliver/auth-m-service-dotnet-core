using System;
using auth_project.Entities;
using Microsoft.EntityFrameworkCore;

namespace auth_project.Data;

public class AuthContext(DbContextOptions<AuthContext> options) 
    : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<UserType> UserTypes => Set<UserType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserType>().HasData(
            new { Id = 1, Type = "Admin"},
            new { Id = 2, Type = "User"}
        );

         modelBuilder.Entity<User>().HasData(
            new { Id = 1, Name = "Administrator", UserName="admin", Email="admin@gmail.com", UserTypeId=1}
        );
    }
}
