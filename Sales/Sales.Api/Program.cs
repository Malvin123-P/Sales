using Microsoft.EntityFrameworkCore;
using Sales.AplicacionCasosDEusos.Contract;
using Sales.AplicacionCasosDEusos.Service;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Repositories;
using Sales.Ioc.CategoryDependecy;
using Sales.Ioc.TDocumentDependency;

var builder = WebApplication.CreateBuilder(args);

// **Agrega el contexto de la base de datos aquí:**
builder.Services.AddDbContext<SalesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SalesContext")));



builder.Services.AddAuthorDependency();

builder.Services.AddConfiguracionDependecy();

builder.Services.AddRolDependecy();


// Repositories
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

builder.Services.AddScoped<IConfiguracionRepository, ConfiguracionRepository>();

builder.Services.AddScoped<IRolRepository, RolRepository>();


// App Services
builder.Services.AddTransient<IAuthorService, AuthorNewService>();

builder.Services.AddTransient<IConfiguracionService, ConfiguracionService>();

builder.Services.AddTransient<IRolService, RolServiceNew>();

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();