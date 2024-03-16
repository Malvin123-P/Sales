using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Dominio.Core
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            this.FechaRegistro = DateTime.Now;
            this.FechaElimino = DateTime.Now;
            this.Eliminado = false;
        }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool Eliminado { get; set; }

    }
}
