using Microsoft.EntityFrameworkCore;
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
    
        
    }
}
