using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregadas
using Editorial.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Core;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Exceptions;
using Microsoft.Extensions.Logging;
using Sales.Infraestructura.Models;
using Sales.Dominio.Entities;


namespace Sales.Infraestructura.Repositories
{

    public class DetalleVentaRepository : BaseRepository<DetalleVenta>, IDetalleVentaRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<DetalleVentaRepository> logger;

        public DetalleVentaRepository(SalesContext context,ILogger<DetalleVentaRepository>logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
        public override List<DetalleVenta> GetEntities()
        {
            return base.GetEntities().Where(ca => ca.Eliminado).ToList();
        }
        public override void Update(DetalleVenta entity)
        {
            try
            {
                var DetalleVentaUpdate = this.GetEntity(entity.id);

                DetalleVentaUpdate.Precio = entity.Precio;
                DetalleVentaUpdate.DescripconProducto = entity.DescripconProducto;
                DetalleVentaUpdate.Cantidad = entity.Cantidad;
                DetalleVentaUpdate.MarcaProducto = entity.MarcaProducto;
                DetalleVentaUpdate.Total = entity.Total;

                this.context.DetalleVenta.Update(DetalleVentaUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizando el detalle de la venta",ex.ToString());
            }
        }
        public override void Save(DetalleVenta entity)
        {
            try
            {
                if (context.DetalleVenta.Any(de => de.id == entity.id))
                {
                    throw new DetalleVentaExcenption("El Detalle de la venta se encuetra registrado.");
                }

                this.context.DetalleVenta.Add(entity);
                this.context.SaveChanges();

            }
            catch (Exception e)
            {
                this.logger.LogError("Error creando el detalle de la venta", e.ToString());
            }
        }
        public override bool Exists(Func<DetalleVenta, bool> filter)
        {
            return base.Exists(filter);
        }


        public List<DetalleVentaModel> GetDetalleVentasByVentas(int idVentas)
        {
            List<DetalleVentaModel> detalleVentas = new List<DetalleVentaModel>();
            try
            {
                detalleVentas = (from detalle in this.context.DetalleVenta
                            join venta in this.context.Ventas on detalle.IdVenta equals venta.id
                            where  detalle.IdVenta == idVentas
                            select new DetalleVentaModel()
                            { 
                                IdVenta = venta.id,
                                IdProducto = venta.id,
                                MarcaProducto = detalle.MarcaProducto,
                                DescripconProducto = detalle.DescripconProducto,
                                Cantidad = detalle.Cantidad,
                                Precio = detalle.Precio,
                                Total = detalle.Total
                               

                            }).ToList();

            }
            catch (Exception e)
            {
                this.logger.LogError("Error obteniendo el detalle de la venta", e.ToString());
            }
            return detalleVentas;
        }

        public List<DetalleVentaModel> GetDetalleVentasbyProducto(int idProducto)
        {
            List<DetalleVentaModel> detalleVentas = new List<DetalleVentaModel>();
            try
            {
                detalleVentas = (from detalle in this.context.DetalleVenta
                                 join producto in this.context.Products on detalle.IdVenta equals producto.id
                                 where detalle.IdProducto == idProducto
                                 select new DetalleVentaModel()
                                 {
                                     

                                 }).ToList();

            }
            catch (Exception e)
            {
                this.logger.LogError("Error obteniendo el detalle de la venta", e.ToString());
            }
            return detalleVentas;
        }
    }

}

