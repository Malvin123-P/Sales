using Sales.AplicacionCasosDEusos.Contract;
using Sales.Application.Core;
using Sales.Application.Dtos.Configuracion;
using Sales.AplicacionCasosDEusos.Models.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Contract
{
    public interface IConfiguracionService : IBaseServices<ConfiguracionDtoAdd, ConfiguracionDtoUpdate, ConfiguracionRemoveDto, ConfiguracionGetModel>
    {

    }
}
