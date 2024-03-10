using Microsoft.EntityFrameworkCore;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//conecxion
builder.Services.AddDbContext<SalesContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SalesContext")));


//repositorios
builder.Services.AddScoped<IDetalleVentaRepository, DetalleVentaRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<INegocioRepository, NegocioRepository>();


//app services


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
