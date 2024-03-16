using Microsoft.Extensions.Logging;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Core;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Models;

namespace Sales.Infraestructura.Repositories
{
    public class RolMenuRepository : BaseRepository<RolMenu>, IRolMenuRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<RolMenuRepository> logger;

        public RolMenuRepository(SalesContext context, ILogger<RolMenuRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public  List<RolMenuModels> GetRolMenuByRolMenu(int Id)
        {
            List<RolMenuModels> rolmenus = new List<RolMenuModels>();
        }

        public  void Update(RolMenu entity)
        {
            try
            {
                var RolMenuToUpdate = this.GetEntity(int.Id);

                if (RolMenuToUpdate == null)
                {
                    throw new RolMenuException("El Menu que busca no existe");
                }

                RolMenuToUpdate.Id = entity.Id;
                RolMenuToUpdate.IdMenu = entity.IdMenu;
                


                this.context.RolMenu.Update(RolMenuToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al actualizar El menu", ex.ToString());
            }
        }

        public void Save(RolMenu entity)
        {
            try
            {
                if (context.RolMenu.Any(c => c.Id == entity.Id))
                {
                    this.logger.LogWarning("El menu que intentas registrar ya se encuentra registrada");
                }

                context.RolMenu.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al registrar el menu", ex.ToString());
            }
        }

        public override RolMenu GetEntity(int id)
        {
            return this.context.RolMenu.Find(id);
        }

        public bool Exists(Func<RolMenu, bool> filter)
        {
            return base.Exists(filter);
        }

        public List<RolMenu> FinAll(Func<RolMenu, bool> filter)
        {
            return base.FinAll(filter);
        }


    }

}