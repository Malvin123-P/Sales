using Sales.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Models
{
    public class NumeroCorrelativoModels
    {
        public int IdNumeroCorrelativo{ get; set; }
        public string NumeroCorrelativo { get; set; }
        public string CantidadDeDigitos{ get; set; }
        public DateTime FechaActualizacion { get; set; }

        
    }
}