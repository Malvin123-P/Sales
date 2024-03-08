﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregadas
using Editorial.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Sales.Dominio.Entities;

namespace Sales.Infraestructura.Context
{
    public class SalesContext : DbContext
    {

        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {
        }

        public DbSet<Category> Categoria {get; set;}
        public DbSet<Producto> Producto { get; set;}
        public DbSet<TipoDocumentoVenta> TipoDocumentoVenta { get; set;}

        #region "DbSets 2021-0189"
        public DbSet<DetalleVenta> DetalleVenta { get;set;}
        public DbSet<Menu> Menu { get; set;}
        public DbSet<Negocio> Negocio { get; set;}

        #endregion

        #region " Store Procedure 2021-0189"
        #endregion

        public DbSet<Venta> Venta { get; set; }
    }
}
