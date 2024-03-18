using Microsoft.Extensions.Logging;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Core;
using Sales.Infraestructura.Interfaces;

namespace Sales.Infraestructura.Repositories
{
    public class RolRepository : BaseRepository<Rol>, IRolRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<RolRepository> logger;

        public RolRepository(SalesContext context, ILogger<RolRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<Rol> GetEntities()
        {
            return this.GetEntities().Where(ca => !ca.Eliminado).ToList();
        }

        public override void Update(Rol entity)
        {
            try
            {
                var rolToUpdate = this.GetEntity(entity.id);

                if (rolToUpdate == null)
                {
                    throw new CategoryException("El rol no existe");
                }

                rolToUpdate.nombre = entity.nombre;
                rolToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                rolToUpdate.Descripcion = entity.Descripcion;
                rolToUpdate.FechaMod = entity.FechaMod;
                rolToUpdate.EsActivo = entity.EsActivo;


                this.context.Rol.Update(rolToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al actualizar el rol", ex.ToString());
            }
        }

        public override void Save(Rol entity)
        {
            try
            {
                if (context.Rol.Any(c => c.id == entity.id))
                {
                    this.logger.LogWarning("La categoría ya se encuentra registrada");
                }

                context.Rol.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al registrar el rol", ex.ToString());
            }
        }

        public override Rol GetEntity(int id)
        {
            return this.context.Rol.Find(id);
        }

        public override bool Exists(Func<Rol, bool> filter)
        {
            return base.Exists(filter);
        }

        public override List<Rol> FinAll(Func<Rol, bool> filter)
        {
            return base.FinAll(filter);
        }

        public override void Remove(Rol entity)
        {
            try
            {
                Rol rolToRemove = this.GetEntity(entity.Descripcion);

                if (rolToRemove is null)
                    throw new RolException("El rol no existe.");

                rolToRemove.Descripcion = entity.Descripcion;
                rolToRemove.EsActivo = entity.EsActivo;
                rolToRemove.IdUsuario = entity.IdUsuario;
                rolToRemove.FechaEliminar = entity.FechaEliminar;


                this.context.Rol.Update(rolToRemove);
                this.context.SaveChanges();


            }
            catch (Exception ex)
            {

                this.logger.LogError("", ex.ToString());
            };
        }
    }
}
        
    

