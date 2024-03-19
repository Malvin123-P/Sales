//Agregadas
using Sales.Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Sales.Infraestructura.Context
{
    public class SalesContext : DbContext
    {

        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {
        }

        #region "DbSets 2021-0189"
        public DbSet<DetalleVenta> DetalleVenta { get;set;}
        public DbSet<Menu> Menu { get; set;}
        public DbSet<Negocio> Negocio { get; set;}

        #endregion

        #region " Store Procedure 2021-0189"
        #endregion

        public DbSet<Venta> Venta { get; set; }

        public DbSet<Producto> Producto { get; set; }
    }
}
