using Microsoft.EntityFrameworkCore;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




// Conn Strings
builder.Services.AddDbContext<SalesContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("SalesContext")));

//Repositories

builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();

// config services cors


// App Services
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
