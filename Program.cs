using auth_project.Data;
using Microsoft.EntityFrameworkCore;
using auth_project.Endpoints;
using auth_project.Interfaces;
using auth_project.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();

var connectionString = builder.Configuration.GetConnectionString("AuthStore");
builder.Services.AddSqlite<AuthContext>(connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// app.MigrateDb(); // from DataExtensions.cs

app.Run();
