using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace Sales.Application.Dtos.Rol

{

    public class RolDtoBase : DtoBase
    {
        public string nombre;

        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public string? IdUsuario { get; set; }
        public string? FechaEliminar { get; set; }
    }

}