using Microsoft.Extensions.Logging;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Core;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Models;

namespace Sales.Infraestructura.Repositories
{
    public class NumeroCorrelativoRepository : BaseRepository<NumeroCorrelativo>, INumeroCorrelativoRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<NumeroCorrelativoRepository> logger;

        public NumeroCorrelativoRepository(SalesContext context, ILogger<NumeroCorrelativoRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public List<NumeroCorrelativoModels> GetNumeroCorrelativo(int UltimoNumero)
        {
            List<NumeroCorrelativoModels> numeroCorrelativos = new List<NumeroCorrelativoModels>();
        }

        public void Update(NumeroCorrelativo entity)
        {
            try
            {
                var NumeroCorrelativoToUpdate = this.GetEntity(entity. UltimoNumero);

                if (NumeroCorrelativoToUpdate == null)
                {
                    throw new NumeroCorrelativoException("El numero correlativo no existe");
                }

                NumeroCorrelativoToUpdate.UltimoNumero = entity.UltimoNumero;
                NumeroCorrelativoToUpdate.CantidadDigitos = entity.CantidadDigitos;
                NumeroCorrelativoToUpdate.Gestion = entity.Gestion;
                NumeroCorrelativoToUpdate.FechaActualizacion = entity.FechaActualizacion;


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
                if (context.NumeroCorrelativo.Any(c => c.UltimoNumero == entity.UltimoNumero))
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

        public  NumeroCorrelativo GetEntity(int id)
        {
            return this.context.NumeroCorrelativo.Find(id);
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