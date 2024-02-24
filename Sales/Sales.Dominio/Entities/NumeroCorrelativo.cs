﻿using Sales.Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Dominio.Entities
{
    public class NumeroCorrelativo: BaseEntity
    {
        public int? UltimoNumero { get; set; }
        public int? CantidadDigitos { get; set; }
        public string? Gestion { get; set; }
        public DateTime? FechaActualizacion {  get; set; }
    }
}
