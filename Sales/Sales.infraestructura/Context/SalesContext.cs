using Editorial.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Sales.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Context
{
    public class SalesContext : DbContext
    {

        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories {get; set;}
        public DbSet<Producto> Products { get; set;}
        public DbSet<TipoDocumentoVenta> TipoDocumentosVenta { get; set;}

        #region "DbSets 2021-0189"
        public DbSet<DetalleVenta> DetalleVenta { get;set;}
        public DbSet<Menu> Menu { get; set;}
        public DbSet<Negocio> Negocio { get; set;}
        #endregion

        #region " Store Procedure 2021-0189"
        #endregion

    }
}
