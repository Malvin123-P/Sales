using Microsoft.Exchange.WebServices.Data;
using Sales.AplicacionCasosDEusos.Models.Configuracion;
using Sales.Application.Core;
using Sales.Application.Dtos.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AplicacionCasosDEusos.Contract.Configuracion
{
    public interface IConfiguracionNewService : IBaseServices<ConfiguracionDtoAdd, ConfiguracionDtoUpdate, ConfiguracionRemoveDto, ConfiguracionGetModel>
    {
        ServicesResult<ConfiguracionGetModel> Get(int configuracionId);
        ServicesResult<List<ConfiguracionGetModel>> GetAll();
    }
}
