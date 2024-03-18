//Agregadas
using Microsoft.Extensions.Logging;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Core;
using Sales.Infraestructura.Exceptions;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Modelos;
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

                if (detalleVentaUpdate is null)
                {
                    throw new DetalleVentaExcenption("El detalle de la venta no existe.");
                }

                detalleVentaUpdate.IdVenta = entity.IdVenta;
                detalleVentaUpdate.Precio = entity.Precio;
                detalleVentaUpdate.DescripcionProducto = entity.DescripcionProducto;
                detalleVentaUpdate.Cantidad = entity.Cantidad;
                detalleVentaUpdate.MarcaProducto = entity.MarcaProducto;
                detalleVentaUpdate.Total = entity.Total;
                detalleVentaUpdate.IdVenta = entity.IdVenta;
                detalleVentaUpdate.FechaMod = entity.FechaMod;
                detalleVentaUpdate.IdProducto = entity.IdProducto;
                detalleVentaUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                detalleVentaUpdate.CategoriaProducto = entity.CategoriaProducto;

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
                    throw new DetalleVentaExcenption("El detalle se encuentra registrado.");
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



        public List<DetalleVentaModel> GetDetalleVentasByVentas(int IdVentas)
        {
            List<DetalleVentaModel> detalleVentas = new List<DetalleVentaModel>();
            try
            {
                detalleVentas = (from detalle in this.context.DetalleVenta
                                 join venta in this.context.Venta on detalle.IdVenta equals venta.Id
                                 where detalle.IdVenta == IdVentas
                                 select new DetalleVentaModel()
                                 {
                                    
                                     IdVenta = venta.Id,
                                     IdProducto = detalle.IdProducto,
                                     MarcaProducto = detalle.MarcaProducto,
                                     DescripcionProducto = detalle.DescripcionProducto,
                                     CategoriaProducto = detalle.CategoriaProducto,
                                     Cantidad = detalle.Cantidad,
                                     Precio = detalle.Precio,
                                     Total = detalle.Total,
                                     FechaRegistro = detalle.FechaRegistro

                                 }).ToList();

               

            }
            catch (Exception e)
            {
                this.logger.LogError("Error obteniendo el detalle de la venta", e.ToString());
            }

            return detalleVentas;
        }

 
        public override void Delete(DetalleVenta entity)
        {
            try
            {
                DetalleVenta detalleVentaRemueve = this.GetEntity(entity.Id);

                if (detalleVentaRemueve is null)
                {
                    throw new DetalleVentaExcenption("El detalle de la venta no existe.");
                }

                detalleVentaRemueve.FechaElimino = entity.FechaElimino;
                detalleVentaRemueve.IdUsuarioElimino = entity.IdUsuarioElimino;
                detalleVentaRemueve.Eliminado = true;

                this.context.DetalleVenta.Update(detalleVentaRemueve);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error Eliminado el detalle de la venta", ex.ToString());
            }
        }

    }

}

