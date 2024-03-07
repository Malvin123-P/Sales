
using Sales.Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Dominio.Entities
{
    public class Producto:BaseEntity
    {
       
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public string? CodigoBarra { get; set; }
        public string? Marca { get; set; }
        public int? IdCategoria { get; set; }
        public int? Stock { get; set; }
        public string? UrlImagen { get; set; }
        public string? NombreImagen { get; set; }
        public decimal? Precio { get; set; }
        

    }
}
