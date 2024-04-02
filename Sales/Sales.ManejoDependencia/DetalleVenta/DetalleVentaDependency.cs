using Microsoft.Extensions.DependencyInjection;
using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.ServiceCasosUsos.DetalleVenta;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Repositories;

namespace Sales.ManejoDependencia.DetalleVenta
{
    public static class DetalleVentaDependency
    {
        public static void AddDetalleVentaDépendencia(this IServiceCollection services)
        {
            services.AddScoped<IDetalleVentaRepository, DetalleVentaRepository>();
            services.AddTransient<IDetalleVentaService, DetalleVentaService>();
        }


    }
}
