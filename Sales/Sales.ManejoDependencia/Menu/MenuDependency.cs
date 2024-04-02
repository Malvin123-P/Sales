using Microsoft.Extensions.DependencyInjection;
using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.ServiceCasosUsos.Menu;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Repositories;

namespace Sales.ManejoDependencia.Menu
{
    public static class MenuDependency
    {
        public static void AddMenuDépendencia(this IServiceCollection services)
        {
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddTransient<IMenuService, MenuService>();
        }
    }
}
