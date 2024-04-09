using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sales.AplicacionCasosDEusos.Dtos.Author
{
    public class AuthorDtoUpdate : AuthorDtoBase
    {
        public string? phone { get; set; }

        public string? address { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zip { get; set; }
    }
}

