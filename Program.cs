using auth_project.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapUserEndpoints();

app.Run();
