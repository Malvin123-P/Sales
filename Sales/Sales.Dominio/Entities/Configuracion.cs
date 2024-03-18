using Sales.Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Dominio.Entities
{
    public class Configuracion:BaseEntity
    {
        public int Id { get; set; }
        public string? Recurso { get; set; }
        public string? Propiedad { get; set; }
        public string? Valor { get; set; }
       
 
    }
}
 