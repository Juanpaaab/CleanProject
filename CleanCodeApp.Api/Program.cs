using CleanCodeApp.Infrastructure.Data;
using CleanCodeApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using CleanCodeApp.Application.Services;
using CleanCodeApp.Domain.Interfaces;
using Microsoft.OpenApi.Models;

using CleanCodeApp.Application.Mappings;
using Mapster;
using MapsterMapper;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CleanCodeApp API",
        Version = "v1",
        Description = "API con arquitectura en capas y principios Clean Code"
    });
});

// Connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección de dependencias
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

// Configurar Mapster
var config = TypeAdapterConfig.GlobalSettings;
MapsterConfig.RegisterMappings(config);
builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanCodeApp API v1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
