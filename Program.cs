global using FastEndpoints;
global using MongoDB.Entities;
using FastEndpoints.Swagger;

var bld = WebApplication.CreateBuilder();
bld.Services
   .AddFastEndpoints()
   .SwaggerDocument();

var app = bld.Build();
app.UseAuthorization()
   .UseFastEndpoints()
   .UseSwaggerGen();

await DB.InitAsync("GridFSAltDemo");

app.Run();