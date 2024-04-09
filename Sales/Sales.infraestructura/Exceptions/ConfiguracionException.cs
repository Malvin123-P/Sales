using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructure.Exceptions
{
    public class ConfiguracionException : Exception
    {
        public ConfiguracionException()
            : base("Ocurrió un error relacionado con los productos.")
        {
        }

        public ConfiguracionException(string message)
            : base(message)
        {
        }

        public ConfiguracionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public int? ConfiguracionId { get; set; }

        public string CodigoConfiguracion { get; set; }

        public string DescripcionConfiguracion { get; set; }
    }
}
