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
    public class NegocioRepository : INegocioRepository
    {
        private readonly SalesContext context;
        public NegocioRepository(SalesContext context)
        {
            this.context = context;
        }

        public void Create(Negocio negocio)
        {
            try
            {
                this.context.Negocio.Add(negocio);
                this.context.SaveChanges();

            }catch(Exception e)
            {
                throw e;
            }
        }

        public List<Negocio> GetNegocio()
        {
            return this.context.Negocio.ToList();
        }

        public Negocio GetNegocio(int Id)
        {
            return this.context.Negocio.Find(Id);
        }

        public void Remove(Negocio negocio)
        {
            try
            {
                Negocio negocioRemuve = this.GetNegocio(negocio.id);
                this.context.Negocio.Remove(negocioRemuve);
                this.context.SaveChanges();
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public void Update(Negocio negocio)
        {
            try
            {
                Negocio negocioUpdate = this.GetNegocio(negocio.id);

                negocioUpdate.Correo = negocio.Correo;
                negocioUpdate.Telefono = negocio.Telefono;
                negocioUpdate.Direccion = negocio.Direccion;
                negocioUpdate.NumeroDocumento = negocio.NumeroDocumento;
                negocioUpdate.Nombre = negocio.Nombre;
                negocioUpdate.NombreLogo = negocio.NombreLogo;
                negocioUpdate.PorcentajeImpuesto = negocio.PorcentajeImpuesto;
                negocioUpdate.SimboloMoneda = negocio.SimboloMoneda;
                negocioUpdate.FechaRegistro = negocio.FechaRegistro;

                this.context.Negocio.Update(negocioUpdate);
                this.context.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
