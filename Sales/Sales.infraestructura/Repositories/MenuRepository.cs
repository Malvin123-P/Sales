using Editorial.Dominio.Entities;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly SalesContext context;
        public MenuRepository(SalesContext context)
        {
            this.context = context;

        }

        public void Create(Menu menu)
        {
            try
            {
                this.context.Menu.Add(menu);
                this.context.SaveChanges();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Menu GetMenu(int Id)
        {
            return this.context.Menu.Find(Id);
        }

        public List<Menu> GetMenus()
        {
            return this.context.Menu.ToList();
        }

        public void Remove(Menu menu)
        {
            try
            {
                Menu menuRemueve = this.GetMenu(menu.id);
                this.context.Menu.Remove(menuRemueve);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Menu menu)
        {
            try
            {
                Menu menuUpdate = this.GetMenu(menu.id);

                menuUpdate.Descripcion = menu.Descripcion;
                menuUpdate.EsActivo = menu.EsActivo;
                menuUpdate.PaginaAccion = menu.PaginaAccion;
                menuUpdate.Icono = menu.Icono;
                menuUpdate.Controlador = menu.Controlador;
            
                this.context.Menu.Update(menuUpdate);
                this.context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
