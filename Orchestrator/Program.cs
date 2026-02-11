using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Data.DbContext;
using Orchestrator.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Загружаются appsettings.json и appsettings.Development.json автоматически

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddCoffeeHouseServices();

var app = builder.Build();

app.MapControllers();

app.Run();
