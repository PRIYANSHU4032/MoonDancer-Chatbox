using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moon.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoUrl"));
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    var mongoSettings = serviceProvider.GetRequiredService<IOptions<MongoSettings>>().Value;
    return new MongoClient(mongoSettings.MongoUrl);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
