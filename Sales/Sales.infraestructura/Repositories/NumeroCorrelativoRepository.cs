using Microsoft.Extensions.Logging;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Core;
using Sales.Infraestructura.Interfaces;

namespace Sales.Infraestructura.Repositories
{
    public class NumeroCorrelativoRepository : BaseRepository<NumeroCorrelativo>, INumeroCorrelativoRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<NumeroCorrelativoRepository> logger;

        public NumeroCorrelativo(SalesContext context, ILogger<NumeroCorrelativoRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<NumeroCorrelativo> GetEntities()
        {
            return this.GetEntities().Where(ca => !ca.Eliminado).ToList();
        }

        public override void Update(NumeroCorrelativo entity)
        {
            try
            {
                var NumeroCorrelativoToUpdate = this.GetEntity(entity.id);

                if (NumeroCorrelativoToUpdate == null)
                {
                    throw new NumeroCorrelativoException("El numero correlativo no existe");
                }

                NumeroCorrelativoToUpdate.nombre = entity.nombre;
                NumeroCorrelativoToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                NumeroCorrelativoToUpdate.FechaMod = entity.FechaMod;
                NumeroCorrelativoToUpdate.EsActivo = entity.EsActivo;


                this.context.NumeroCorrelativo.Update(NumeroCorrelativoToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al actualizar El numero Correlativo", ex.ToString());
            }
        }

        public override void Save(NumeroCorrelativo entity)
        {
            try
            {
                if (context.NumeroCorrelativo.Any(c => c.id == entity.id))
                {
                    this.logger.LogWarning("La categoría ya se encuentra registrada");
                }

                context.NumeroCorrelativo.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al registrar el Numero Correlativo", ex.ToString());
            }
        }

        public override Category GetEntity(int id)
        {
            return this.context.Categories.Find(id);
        }

        public override bool Exists(Func<NumeroCorrelativo, bool> filter)
        {
            return base.Exists(filter);
        }

        public override List<NumeroCorrelativo> FinAll(Func<NumeroCorrelativo, bool> filter)
        {
            return base.FinAll(filter);
        }


    }

}