﻿using Sales.AplicacionCasosDEusos.Dtos.Configuracion;
using Sales.AplicacionCasosDEusos.Models.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AplicacionCasosDEusos.Contract.Configuracion
{
    internal interface IConfiguracionNewService : IBaseService<ConfiguracionDto, ConfiguracionUpdateDto, ConfiguracionRemoveDto, ConfiguracionGetModel>
    {
    }
}
