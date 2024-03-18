using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Models
{
     public class ProductoModel
    {
        public int ProductoId { get; set; }
        public string? ProductoName { get; set;}
        public string? CategoryName  { get; set;}
        public decimal Precio {  get; set; }
        public string? Marca {  get; set; }
        public int Stock {  get; set; }

    }
}
