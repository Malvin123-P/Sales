using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AplicacionCasosDEusos.Dtos.Validations
{
    public static class AuthorValidation
    {
        public static void CommonValidation(string phone, string address, string city, string state, string zip, IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(phone))
            {
                string ErrorMessage = $"{configuration["MensajeValidaciones: El telefono es requerido"]}";
                throw new Exception(ErrorMessage);
            }
        }
    }
}