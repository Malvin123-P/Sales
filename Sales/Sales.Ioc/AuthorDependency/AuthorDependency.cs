using Microsoft.Extensions.DependencyInjection;
using Sales.AplicacionCasosDEusos.Contract;
using Sales.AplicacionCasosDEusos.Contract.Author;
using Sales.AplicacionCasosDEusos.Service;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.AplicacionCasosDEusos.Service.Author;


namespace Sales.Ioc.AuthorDependecy
{
    public static class AuthorDependency
    {
        public static void AddAuthorDependency(this IServiceCollection services)
        {
            // Repositories

            services.AddScoped<IAuthorRepository, IAuthorRepository>();

            // App services

            services.AddScoped<IAuthorNewService, IAuthorNewService>();
        }
    }
}