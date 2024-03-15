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
        
        public class SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {
        }

    public DbSet<Categoria> Categories { get; set; }
    public DbSet<Producto> Products { get; set; }
    public DbSet<TipoDocumentoVenta> TipoDocumentosVenta { get; set; }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>()
            .Property(p => p.Precio)
            .HasColumnType("decimal(10,2)");
    
        
    }