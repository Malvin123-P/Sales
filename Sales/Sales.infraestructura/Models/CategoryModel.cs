using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Models
{
    public class CategoriaModel
    {
        public int? IdCategoria { get; set; }
        public string? Descripcion {  get; set; }
        public int? FechaCreacion { get; set; }
    }
}
