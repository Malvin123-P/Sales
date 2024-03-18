﻿namespace Sales.Api.Dtos.Rol
{
    public class RolUpdateDto : RolDtoBase
    {
        public string nombre;

        public int Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public string? IdUsuario { get; set; }
        public string? FechaEliminar { get; set; }
    }
}

