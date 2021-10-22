global using FastEndpoints;
global using FastEndpoints.Validation;
global using MongoDB.Entities;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddSwagger();

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwagger();
app.UseSwaggerUI();

await DB.InitAsync("GridFSAltDemo");

app.Run();