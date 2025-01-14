﻿var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocument(options =>
{
    options.DocumentName = "My Amazing API";
    //options.Version = "V1";
});
builder.Services.AddHttpClient("disney", configureClient: client =>
{
    client.BaseAddress = new Uri("https://api.disneyapi.dev/characters");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
app.UseOpenApi();
app.UseSwaggerUi3();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

