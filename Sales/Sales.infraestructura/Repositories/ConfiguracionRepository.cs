using Microsoft.Extensions.Logging;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructura.Interfaces;

namespace Sales.Infraestructura.Repositories
{
    public class ConfiguracionRepository : BaseRepository<Configuracion>, IConfiguracionRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<ConfiguracionRepository> logger;

        public ConfiguracionRepository(SalesContext context, ILogger<ConfiguracionRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<Configuracion> GetEntities()
        {
            return this.GetEntities().Where(ca => !ca.Eliminado).ToList();
        }

        public override void Update(Configuracion entity)
        {
            try
            {
                var configuracionToUpdate = this.GetEntity(entity.id);

                if (configuracionToUpdate == null)
                {
                    throw new CategoryException("La configuracion no existe");
                }

                configuracionToUpdate.Recurso = entity.Recurso;
                configuracionToUpdate.Propiedad = entity.Propiedad;
                configuracionToUpdate.Valor = entity.Valor;
                


                this.context.Configuracion.Update(configuracionToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al actualizar la configuracion", ex.ToString());
            }
        }

        public override void Save(Configuracion entity)
        {
            try
            {
                if (context.Rol.Any(c => c.id == entity.id))
                {
                    this.logger.LogWarning("La configuracion ya se encuentra registrado");
                }

                context.Configuracion.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al registrar la configuracion", ex.ToString());
            }
        }

        public override Configuracion GetEntity(int id)
        {
            return this.context.Configuracion.Find(id);
        }

        public override bool Exists(Func<Configuracion, bool> filter)
        {
            return base.Exists(filter);
        }

        public override List<Configuracion> FinAll(Func<Configuracion, bool> filter)
        {
            return base.FinAll(filter);
        }

        
    }
    
}
