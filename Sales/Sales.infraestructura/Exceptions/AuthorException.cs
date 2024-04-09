using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructure.Exceptions
{
    public class AuthorException : Exception
    {

        public AuthorException()
            : base("Ocurrió un error relacionado con los autores.")
        {
        }

        public AuthorException(string message)
            : base(message)
        {
        }

        public AuthorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public int? AuthorId { get; set; }

        public string AuthorName { get; set; }

    }
}