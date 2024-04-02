using Microsoft.EntityFrameworkCore;
using Sales.Infraestructura.Context;
using Sales.ManejoDependencia.DetalleVenta;
using Sales.ManejoDependencia.Menu;
using Sales.ManejoDependencia.Negocio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
