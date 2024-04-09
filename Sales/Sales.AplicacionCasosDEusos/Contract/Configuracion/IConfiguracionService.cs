using Sales.AplicacionCasosDEusos.Contract;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Configuracion;
using Sales.AplicacionCasosDEusos.Models.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Contract
{
    public interface IConfiguracionService : IBaseServices<ConfiguracionDtoAdd, ConfiguracionDtoUpdate, ConfiguracionDtoRemove, ConfiguracionGetModel>
    {

    }
}
