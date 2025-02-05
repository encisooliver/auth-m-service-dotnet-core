using auth_project.Data;
using auth_project.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AuthStore");
builder.Services.AddSqlite<AuthContext>(connectionString);

var app = builder.Build();

app.MapUserEndpoints();
app.MigrateDb(); // from DataExtensions.cs

app.Run();
