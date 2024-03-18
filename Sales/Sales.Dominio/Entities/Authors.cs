using Sales.Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Dominio.Entities
{
    public class Authors : BaseEntity
    {
        public string? nombre;

        public int phone { get; set; }

        public string? address { get; set; }
        public string? state { get; set; }
        public string? city { get; set; }
        public string? zip { get; set; }
    }
}
