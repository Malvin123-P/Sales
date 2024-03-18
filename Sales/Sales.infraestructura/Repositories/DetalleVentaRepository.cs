//Agregadas



using Microsoft.Extensions.Logging;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Core;
using Sales.Infraestructura.Exceptions;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Models;


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
            return base.GetEntities().Where(dv => !dv.Eliminado).ToList();
        }
        public override void Update(DetalleVenta entity)
        {
            try
            {
                DetalleVenta detalleVentaUpdate = this.GetEntity(entity.Id);

                detalleVentaUpdate.Precio = entity.Precio;
                detalleVentaUpdate.DescripcionProducto = entity.DescripcionProducto;
                detalleVentaUpdate.Cantidad = entity.Cantidad;
                detalleVentaUpdate.MarcaProducto = entity.MarcaProducto;
                detalleVentaUpdate.Total = entity.Total;

                this.context.DetalleVenta.Update(detalleVentaUpdate);
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
                if (context.DetalleVenta.Any(dv => dv.Id == entity.Id))
                {
                    throw new MenuExcenption("El detalle se encuetra registrado.");
                }

                this.context.DetalleVenta.Add(entity);
                this.context.SaveChanges();

            }
            catch (Exception e)
            {
                this.logger.LogError("Error creando el detalle", e.ToString());
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
                                 join Venta in this.context.Venta on detalle.IdVenta equals Venta.Id
                                 where detalle.IdVenta == idVentas
                                 select new DetalleVentaModel()
                                 {
                                     IdVenta = Venta.Id,
                                     IdProducto = detalle.IdProducto,
                                     MarcaProducto = detalle.MarcaProducto,
                                     DescripcionProducto = detalle.DescripcionProducto,
                                     Cantidad = detalle.Cantidad,
                                     Precio = detalle.Precio,
                                     Total = detalle.Total,
                                     CategoriaProducto = detalle.CategoriaProducto


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
                                 join producto in this.context.Producto on detalle.IdProducto equals producto.Id
                                 where detalle.IdProducto == idProducto
                                 select new DetalleVentaModel()
                                 {

                                     IdProducto = producto.Id,
                                     IdVenta = detalle.Id,
                                     MarcaProducto = detalle.MarcaProducto,
                                     DescripcionProducto = detalle.DescripcionProducto,
                                     Cantidad = detalle.Cantidad,
                                     Precio = detalle.Precio,
                                     Total = detalle.Total,
                                     CategoriaProducto = detalle.CategoriaProducto


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

