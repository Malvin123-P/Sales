using Sales.Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Dominio.Entities
{
    sealed internal class ClassNegocio:ClassBase
    {
        public string? UrlLogo { get; set; }
        public string? NombreLogo {  get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombre {  get; set; }
        public string? Correo {  get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public decimal? PorcentajeImpuesto { get; set;}
        public string? SimboloMoneda { get; set;}

    }
}
