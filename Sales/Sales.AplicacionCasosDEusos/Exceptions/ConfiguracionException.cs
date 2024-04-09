using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sales.AplicacionCasosDEusos.Exceptions
{
    internal class ConfiguracionException : Exception
    {
        public ConfiguracionException(string message) : base(message)
        {

        }
    }
}
