using Microsoft.EntityFrameworkCore;
using Sales.Infraestructura.Context;
using Sales.ManejoDependencia.DetalleVenta;
using Sales.ManejoDependencia.Menu;
using Sales.ManejoDependencia.Negocio;

var builder = WebApplication.CreateBuilder(args);

//conecxion
builder.Services.AddDbContext<SalesContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SalesContext")));

//ManejoDependencia
builder.Services.AddDetalleVentaDépendencia();
builder.Services.AddMenuDépendencia();
builder.Services.AddNegocioDépendencia();

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
