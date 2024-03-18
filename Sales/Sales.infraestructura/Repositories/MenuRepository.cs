
//Agregadas
using Sales.Dominio.Entities;
using Microsoft.Extensions.Logging;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Core;
using Sales.Infraestructura.Exceptions;
using Sales.Infraestructura.Interfaces;

namespace Sales.Infraestructura.Repositories
{
    public class MenuRepository :BaseRepository<Menu>, IMenuRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<MenuRepository> logger;

        public MenuRepository(SalesContext context,ILogger<MenuRepository> logger) :base(context) 
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<Menu> GetEntities()
        {
            return base.GetEntities().Where(ca => !ca.Eliminado).ToList();
        }

        public override void Update(Menu entity)
        {
            try
            {
                Menu menuUpdate = this.GetEntity(entity.Id);

                menuUpdate.Descripcion = entity.Descripcion;
                menuUpdate.EsActivo = entity.EsActivo;
                menuUpdate.PaginaAccion = entity.PaginaAccion;
                menuUpdate.Icono = entity.Icono;
                menuUpdate.Controlador = entity.Controlador;

                this.context.Menu.Update(menuUpdate);
                this.context.SaveChanges();

    }
            catch (Exception e)
            {
                this.logger.LogError("Error actualizando el menu", e.ToString());
            }
        }

        public override void Save(Menu entity)
        {
            try
            {
                if (context.Menu.Any(me => me.Id == entity.Id))
                {
                    throw new MenuExcenption("El menu se encuetra registrado.");
                }

                this.context.Menu.Add(entity);
                this.context.SaveChanges();

            }
            catch (Exception e)
            {
                this.logger.LogError("Error creando el Menu", e.ToString());
            }
        }
        public override bool Exists(Func<Menu, bool> filter)
        {
            return base.Exists(filter);
        }

    }
}
