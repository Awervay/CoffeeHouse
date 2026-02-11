using Data.DbContext;
using Orchestrator.Extensions;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddCoffeeHouseServices();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
