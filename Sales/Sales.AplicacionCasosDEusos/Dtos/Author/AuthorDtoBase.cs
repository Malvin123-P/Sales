using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Dtos.Author
{
    public class AuthorDtoBase : DtoBase
    {
        public int phone { get; set; }

        public string? address { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zip { get; set; }
    }
}
