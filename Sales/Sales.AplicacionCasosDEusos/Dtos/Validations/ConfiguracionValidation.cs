using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AplicacionCasosDEusos.Dtos.Validations
{
    public static class ConfiguracionValidation
    { 
    public static void CommonValidation(string recurso, string propiedad, string valor, IConfiguration configuration)
    {
        if (string.IsNullOrEmpty(recurso))
        {
            string ErrorMessage = $"{configuration["MensajeValidaciones: La DescripcionEsRequerida"]}";
            throw new Exception(ErrorMessage);
        }
    }
}
}