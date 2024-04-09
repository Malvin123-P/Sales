using Microsoft.Extensions.DependencyInjection;
using Sales.AplicacionCasosDEusos.Contract;
using Sales.AplicacionCasosDEusos.Contract.Rol;
using Sales.AplicacionCasosDEusos.Service;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.AplicacionCasosDEusos.Service.Rol;


namespace Sales.Ioc.RolDependecy
{
    public static class RolDependency
    {
        public static void AddRolDependency(this IServiceCollection services)
        {
            // Repositories

            services.AddScoped<IRolRepository, IRolRepository>();

            // App services

            services.AddScoped<IRolNewService, IRolNewService>();
        }
    }
}