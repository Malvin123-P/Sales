using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregadas
using Microsoft.Extensions.Logging;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Core;
using Sales.Infraestructura.Exceptions;
using Sales.Infraestructura.Interfaces;

namespace Sales.Infraestructura.Repositories
{
    public class NegocioRepository :BaseRepository<Negocio>,INegocioRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<NegocioRepository> logger;

        public NegocioRepository(SalesContext context, ILogger<NegocioRepository> logger):base(context)
        {
            this.context = context;
            this.logger = logger;
            
        }


        public override List<Negocio> GetEntities()
        {
            return base.GetEntities().Where(ca => !ca.Eliminado).ToList();
        }

        public override void Update(Negocio entity)
        {
            try
            {
                Negocio negocioUpdate = this.GetEntity(entity.Id);

                if (negocioUpdate is null)
                {
                    throw new NegocioExcenption("EL NEGOCIO NO EXISTE.");
                }

                negocioUpdate.UrlLogo = entity.UrlLogo;
                negocioUpdate.Correo = entity.Correo;
                negocioUpdate.Telefono = entity.Telefono;
                negocioUpdate.Direccion = entity.Direccion;
                negocioUpdate.NumeroDocumento = entity.NumeroDocumento;
                negocioUpdate.Nombre = entity.Nombre;
                negocioUpdate.NombreLogo = entity.NombreLogo;
                negocioUpdate.PorcentajeImpuesto = entity.PorcentajeImpuesto;
                negocioUpdate.SimboloMoneda = entity.SimboloMoneda;
                negocioUpdate.FechaMod = entity.FechaMod;
                negocioUpdate.IdUsuarioMod = entity.IdUsuarioMod;

                this.context.Negocio.Update(negocioUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("ERROR ACTUALIZANDO EL NEGOCIO.", ex.ToString());
            }
        }

        public override void Save(Negocio entity)
        {
            try
            {
                if (context.Negocio.Any(ne => ne.Id == entity.Id))
                {
                    throw new NegocioExcenption("EL NEGOCIO SE ENCUENTRA REGISTRADO.");
                }

                this.context.Negocio.Add(entity);
                this.context.SaveChanges();

            }
            catch (Exception e)
            {
                this.logger.LogError("ERROR CREANDO EL NEGOCIO.", e.ToString());
            }
        }

        public override bool Exists(Func<Negocio, bool> filter)
        {
            return base.Exists(filter);
        }

        public override void Delete(Negocio entity)
        {
            try
            {
                Negocio negocioRemueve = this.GetEntity(entity.Id);
                if (negocioRemueve is null)
                {
                    throw new NegocioExcenption("El NEGOCIO NO EXISTE.");
                }

                negocioRemueve.FechaElimino = entity.FechaElimino;
                negocioRemueve.IdUsuarioElimino = entity.IdUsuarioElimino;
                negocioRemueve.Eliminado = true;

                this.context.Negocio.Update(negocioRemueve);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("ERROR ELIMINAOD EL NEGOCIO.", ex.ToString());
            }
        }

    }
}




