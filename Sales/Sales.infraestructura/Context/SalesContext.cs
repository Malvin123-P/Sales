using Microsoft.EntityFrameworkCore;
using Sales.Dominio.Entities;
using System;
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

        public DbSet<Author> Author { get; set; }
        public DbSet<Configuracion> Configuracion { get; set; }
        public DbSet<Rol> Rol { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(p => p.phone)
                .HasColumnType("decimal(10,2)");
        }

    }
}
