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

                negocioUpdate.Correo = entity.Correo;
                negocioUpdate.Telefono = entity.Telefono;
                negocioUpdate.Direccion = entity.Direccion;
                negocioUpdate.NumeroDocumento = entity.NumeroDocumento;
                negocioUpdate.Nombre = entity.Nombre;
                negocioUpdate.NombreLogo = entity.NombreLogo;
                negocioUpdate.PorcentajeImpuesto = entity.PorcentajeImpuesto;
                negocioUpdate.SimboloMoneda = entity.SimboloMoneda;
                negocioUpdate.FechaRegistro = entity.FechaRegistro;

                this.context.Negocio.Update(negocioUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizando el negocio", ex.ToString());
            }
        }

        public override void Save(Negocio entity)
        {
            try
            {
                if (context.Negocio.Any(de => de.Nombre == entity.Nombre))
                {
                    throw new NegocioExcenption("El negocio se encuetra registrado.");
                }

                this.context.Negocio.Add(entity);
                this.context.SaveChanges();

            }
            catch (Exception e)
            {
                this.logger.LogError("Error creando el negocio", e.ToString());
            }
        }

        public override bool Exists(Func<Negocio, bool> filter)
        {
            return base.Exists(filter);
        }

    }
}
