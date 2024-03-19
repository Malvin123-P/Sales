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

                if (detalleVentaUpdate is null)
                {
                    throw new DetalleVentaExcenption("DETALLE NO EXISTE.");
                }

                detalleVentaUpdate.IdVenta = entity.IdVenta;
                detalleVentaUpdate.Precio = entity.Precio;
                detalleVentaUpdate.IdProducto = entity.IdProducto;
                detalleVentaUpdate.DescripcionProducto = entity.DescripcionProducto;
                detalleVentaUpdate.Cantidad = entity.Cantidad;
                detalleVentaUpdate.MarcaProducto = entity.MarcaProducto;
                detalleVentaUpdate.Total = entity.Total;
                detalleVentaUpdate.CategoriaProducto = entity.CategoriaProducto;
                detalleVentaUpdate.FechaMod = entity.FechaMod; 
                detalleVentaUpdate.IdUsuarioMod = entity.IdUsuarioMod;
               
                this.context.DetalleVenta.Update(detalleVentaUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("ERROR ACTUALIZANDO EL DETALLE.",ex.ToString());
            }
        }
        public override void Save(DetalleVenta entity)
        {
            try
            {
                if (context.DetalleVenta.Any(dv => dv.Id == entity.Id))
                {
                    throw new DetalleVentaExcenption("DETALLE SE ENCUENTRA REGISTRADO.");
                }

                this.context.DetalleVenta.Add(entity);
                this.context.SaveChanges();

            }
            catch (Exception e)
            {
                this.logger.LogError("ERROR CREANDO EL DETALLE.", e.ToString());
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
                                 join Venta in this.context.Venta on detalle.IdVenta equals Venta.Id
                                 where detalle.IdVenta == IdVentas
                                 select new DetalleVentaModel()
                                 {                                 
                                     IdVenta = Venta.Id,
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
                this.logger.LogError("ERROR OBTENIENDO EL DETALLE.", e.ToString());
            }
            return detalleVentas;
        }

        public List<DetalleVentaModel> GetDetalleVentasbyProducto(int IdProducto)
        {
            List<DetalleVentaModel> detalleVentas = new List<DetalleVentaModel>();
            try
            {
                detalleVentas = (from detalle in this.context.DetalleVenta
                                 join producto in this.context.Producto on detalle.IdProducto equals producto.Id
                                 where detalle.IdProducto == IdProducto
                                 select new DetalleVentaModel()
                                 {                                  
                                     IdVenta = detalle.IdVenta,
                                     IdProducto = producto.Id,
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
                this.logger.LogError("ERROR OBTENIENDO EL DETALLE.", e.ToString());
            }
            return detalleVentas;
        }
        public override void Delete(DetalleVenta entity)
        {
            try
            {
                DetalleVenta detalleVentaoRemueve = this.GetEntity(entity.Id);

                if (detalleVentaoRemueve is null)
                {
                    throw new NegocioExcenption("DETALLE NO EXISTE.");
                }

                detalleVentaoRemueve.FechaElimino = entity.FechaElimino;
                detalleVentaoRemueve.IdUsuarioElimino = entity.IdUsuarioElimino;
                detalleVentaoRemueve.Eliminado = true;

                this.context.DetalleVenta.Update(detalleVentaoRemueve);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("ERROR ELIMINANDO DETALLE", ex.ToString());
            }
        }

    }

}

