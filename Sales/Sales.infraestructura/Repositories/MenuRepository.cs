﻿
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
            return base.GetEntities().Where(me => !me.Eliminado).ToList();
        }

        public override void Update(Menu entity)
        {
            try
            {
                Menu menuUpdate = this.GetEntity(entity.Id);

                if (menuUpdate is null)
                {
                    throw new MenuExcenption("El menu no existe.");
                }

                menuUpdate.Descripcion = entity.Descripcion;
                menuUpdate.EsActivo = entity.EsActivo;
                menuUpdate.PaginaAccion = entity.PaginaAccion;
                menuUpdate.Icono = entity.Icono;
                menuUpdate.Controlador = entity.Controlador;
                menuUpdate.IdMenuPadre = entity.IdMenuPadre;
                menuUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                menuUpdate.FechaMod = entity.FechaMod;

                this.context.Menu.Update(menuUpdate);
                this.context.SaveChanges();

    }
            catch (Exception e)
            {
                this.logger.LogError("ERROR ACTUALIZANDO EL MENU.", e.ToString());
            }
        }

        public override void Save(Menu entity)
        {
            try
            {
                if (context.Menu.Any(me => me.Id == entity.Id))
                {
                    throw new MenuExcenption("EL MENU SE ENCUENTRA REGISTRADO.");
                }

                this.context.Menu.Add(entity);
                this.context.SaveChanges();

            }
            catch (Exception e)
            {
                this.logger.LogError("ERROR CREANDO EL MENU.", e.ToString());
            }
        }
        public override bool Exists(Func<Menu, bool> filter)
        {
            return base.Exists(filter);
        }

        public override void Delete(Menu entity)
        {
            try
            {
                Menu menuRemueve = this.GetEntity(entity.Id);
                if (menuRemueve is null)
                {
                    throw new MenuExcenption("El MENU NO EXISTE.");
                }

                menuRemueve.FechaElimino = entity.FechaElimino;
                menuRemueve.IdUsuarioElimino = entity.IdUsuarioElimino;
                menuRemueve.Eliminado = true;

                this.context.Menu.Update(menuRemueve);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("ERROR ELIMINANDO EL MENU.", ex.ToString());
            }
        }

    }
}
 