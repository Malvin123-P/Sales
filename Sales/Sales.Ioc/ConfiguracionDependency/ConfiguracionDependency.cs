using Microsoft.Extensions.DependencyInjection;
using Sales.AplicacionCasosDEusos.Contract;
using Sales.AplicacionCasosDEusos.Contract.Configuracion;
using Sales.AplicacionCasosDEusos.Service;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.AplicacionCasosDEusos.Service.Configuracion;


namespace Sales.Ioc.ConfiguracionDependecy
{
    public static class ConfiguracionDependency
    {
        public static void AddConfiguracionDependency(this IServiceCollection services)
        {
            // Repositories

            services.AddScoped<IConfiguracionRepository, IConfiguracionRepository>();

            // App services

            services.AddScoped<IConfiguracionNewService, IConfiguracionNewService>();
        }
    }
}
