using Sales.AplicacionCasosDEusos.Contract;
using Sales.AplicacionCasosDEusos.Models.Rol;
using Sales.Application.Core;
using Sales.Application.Dtos.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Sales.Application.Contract
{
    public interface IRolService : IBaseServices<RolDtoAdd, RolDtoUpdate, RolRemoveDto, RolGetModel>
    {

    }
}
