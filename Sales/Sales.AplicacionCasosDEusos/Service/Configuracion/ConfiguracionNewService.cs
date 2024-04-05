using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contract;
using Sales.AplicacionCasosDEusos.Contract.Configuracion;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Configuracion;
using Sales.AplicacionCasosDEusos.Dtos.Configuracion;
using Sales.AplicacionCasosDEusos.Dtos.Configuracion;
using Sales.AplicacionCasosDEusos.Dtos.Enums;
using Sales.AplicacionCasosDEusos.Models.Configuracion;
using Sales.AplicacionCasosDEusos.Service.Configuracion;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Repositories;
using System.Runtime.CompilerServices;

namespace Sales.AplicacionCasosDEusos.Service.Configuracion
{
    public class ConfiguracionNewService : IConfiguracionNewService
    {
        private readonly ILogger<ConfiguracionService> logger;

        public ServiceResult<ConfiguracionGetModel> Get(int authorId)
        {
            throw new NotImplementedException();
        }

        public global::ServiceResult<ConfiguracionGetModel> Get(int authorId, int configuracionId)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<List<ConfiguracionGetModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResult<ConfiguracionGetModel> Remove(ConfiguracionRemoveDto configuracionesRemoveDto)
        {
            throw new NotImplementedException();
        }

        public global::ServiceResult<ConfiguracionGetModel> Remove(ConfiguracionRemoveDto authorsRemoveDto, ConfiguracionRemoveDto configuracionRemoveDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<ConfiguracionGetModel> Save(ConfiguracionDto configuracionDto)
        {
            throw new NotImplementedException();
        }

        public global::ServiceResult<ConfiguracionGetModel> Save(ConfiguracionDto authorDto, ConfiguracionDto configuracionDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<ConfiguracionGetModel> Update(ConfiguracionUpdateDto configuracionUpdateDto)
        {
            throw new NotImplementedException();
        }

        public global::ServiceResult<ConfiguracionGetModel> Update(ConfiguracionUpdateDto authorsUpdateDto, ConfiguracionUpdateDto configuracionUpdateDto)
        {
            throw new NotImplementedException();
        }

        global::ServiceResult<ConfiguracionGetModel> IConfiguracionNewService.Get(int configuracionId)
        {
            throw new NotImplementedException();
        }

        global::ServiceResult<List<ConfiguracionGetModel>> IConfiguracionNewService.GetAll()
        {
            throw new NotImplementedException();
        }

        global::ServiceResult<List<ConfiguracionGetModel>> IBaseService<ConfiguracionDto, ConfiguracionUpdateDto, ConfiguracionRemoveDto, ConfiguracionGetModel>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}



