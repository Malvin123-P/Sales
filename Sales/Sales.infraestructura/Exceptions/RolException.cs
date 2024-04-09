using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructure.Exceptions
{
    public class RolException : Exception
    {
        public RolException()
            : base("Ocurrió un error relacionado con los productos.")
        {
        }

        public RolException(string message)
            : base(message)
        {
        }

        public RolException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public int? ConfiguracionId { get; set; }

        public string CodigoConfiguracion { get; set; }

        public string DescripcionConfiguracion { get; set; }
    }
}
