using Sales.Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sales.Dominio.Entities
{
    public class RolMenu:BaseEntity
    {
       
        public int? IdRol { get; set; }
        public int? IdMenu { get; set; }
        public bool? EsActivo { get; set; }

    }
}
