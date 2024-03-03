using Editorial.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Repositories
{
    public class DetalleVentaRepository : IDetalleVentaRepository
    {
        private readonly SalesContext context;
        public DetalleVentaRepository(SalesContext context)
        {
            this.context = context;
        }

        public void Create(DetalleVenta detalleVenta)
        {
            try
            {
                this.context.DetalleVenta.Add(detalleVenta);
                this.context.SaveChanges();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<DetalleVenta> GetDetalleVentas()
        {
            return this.context.DetalleVenta.ToList();
        }

        public DetalleVenta GetTDetalleVenta(int Id)
        {
            return this.context.DetalleVenta.Find(Id);
        }

        public void Remove(DetalleVenta detalleVenta)
        {
            try
            {
                DetalleVenta DetalleVentaRemueve = this.GetTDetalleVenta(detalleVenta.id);
                this.context.DetalleVenta.Remove(DetalleVentaRemueve);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(DetalleVenta detalleVenta)
        {
            try
            {
                DetalleVenta DetalleVentaUpdate = this.GetTDetalleVenta(detalleVenta.id);

                DetalleVentaUpdate.Precio = detalleVenta.Precio;
                DetalleVentaUpdate.DescripconProducto = detalleVenta.DescripconProducto;
                DetalleVentaUpdate.Cantidad = detalleVenta.Cantidad;
                DetalleVentaUpdate.MarcaProducto = detalleVenta.MarcaProducto;
                DetalleVentaUpdate.Total = detalleVenta.Total;
    
                this.context.DetalleVenta.Update(DetalleVentaUpdate);
                this.context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
