using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Validations
{
    public static class RolValidation
    {
        public static void CommonValidation(string FechaEliminar, string IdUsuario, string EsActivo, int Descripcion, IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(IdUsuario))
            {
                string ErrorMessage = $"{configuration["MensajeValidaciones: La DescripcionEsRequerida"]}";
                throw new Exception(ErrorMessage);
            }
        }
    }
}
