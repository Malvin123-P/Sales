using Microsoft.EntityFrameworkCore;
using Sales.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Context
{
    public class SalesContext: DbContext
    {

        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        { 
        }
        public DbSet<NumeroCorrelativo> NumeroCorrelativo { get; set; }
        public DbSet<RolMenu> RolMenu { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolMenu>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(10,2)");
        }
    }
    
          }