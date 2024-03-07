﻿using Sales.Dominio.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Dominio.Entities
{
  
    public class Category:BaseEntity
    {
        public string? Nombre {  get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }

    }
}
