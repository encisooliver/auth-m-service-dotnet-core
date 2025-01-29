using System;
using auth_project.Entities;
using Microsoft.EntityFrameworkCore;

namespace auth_project.Data;

public class AuthContext(DbContextOptions<AuthContext> options) 
    : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<UserType> UserTypes => Set<UserType>();
}
