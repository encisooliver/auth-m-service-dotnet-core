using System;
using auth_project.Models;
using Microsoft.EntityFrameworkCore;

namespace auth_project.Data;

public class AuthContext(DbContextOptions<AuthContext> options) 
    : DbContext(options)
{
    public DbSet<UserModel> Users => Set<UserModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserModel>().HasData(
            new { Id = 1, Name = "Administrator", UserName="admin", Email="admin@gmail.com", Password="123456" }
        );
    }
}
