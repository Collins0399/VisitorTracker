using Microsoft.EntityFrameworkCore;
using VisitorTracker.Data;
using VisitorTracker.Interfaces;
using VisitorTracker.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register the VisitorService with the dependency injection container, associating it with the IVisitorService interface
builder.Services.AddScoped<IVisitorService, VisitorService>();

// Read the connection string from appsettings.json
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

// Register the ApplicationDbContext with the dependency injection container, configuring it to use SQL Server with the specified connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
