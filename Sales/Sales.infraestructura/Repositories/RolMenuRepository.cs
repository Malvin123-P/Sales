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

        public NumeroCorrelativo(SalesContext context, ILogger<RolMenuRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<RolMenu> GetEntities()
        {
            return this.GetEntities().Where(ca => !ca.Eliminado).ToList();
        }

        public override void Update(RolMenu entity)
        {
            try
            {
                var RolMenuToUpdate = this.GetEntity(entity.id);

                if (RolMenuToUpdate == null)
                {
                    throw new RolMenuException("El Menu que busca no existe");
                }

                RolMenuToUpdate.nombre = entity.nombre;
                RolMenuToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                RolMenuToUpdate.IdUsuarioCreacion = entity.IdUsuarioCreacion;
                RolMenuToUpdate.FechaMod = entity.FechaMod;
                RolMenuToUpdate.EsActivo = entity.EsActivo;
                RolMenuToUpdate.IdMenu = entity.IdMenu;


                this.context.RolMenu.Update(RolMenuToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al actualizar El menu", ex.ToString());
            }
        }

        public override void Save(RolMenu entity)
        {
            try
            {
                if (context.RolMenu.Any(c => c.id == entity.id))
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

        public override Category GetEntity(int id)
        {
            return this.context.RolMenu.Find(id);
        }

        public override bool Exists(Func<RolMenu, bool> filter)
        {
            return base.Exists(filter);
        }

        public override List<RolMenu> FinAll(Func<RolMenu, bool> filter)
        {
            return base.FinAll(filter);
        }


    }

}