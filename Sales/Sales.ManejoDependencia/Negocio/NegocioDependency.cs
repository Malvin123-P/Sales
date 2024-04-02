using Microsoft.Extensions.DependencyInjection;
using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.ServiceCasosUsos.Negocio;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Repositories;

namespace Sales.ManejoDependencia.Negocio
{
    public static class NegocioDependency
    {
        public static void AddNegocioDépendencia(this IServiceCollection services)
        {
            services.AddScoped<INegocioRepository, NegocioRepository>();
            services.AddTransient<INegocioService, NegocioService>();
        }

    }
}
