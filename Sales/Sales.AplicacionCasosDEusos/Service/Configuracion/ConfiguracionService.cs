

using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contract.Configuracion;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Configuracion;
using Sales.AplicacionCasosDEusos.Dtos.Configuracion;
using Sales.AplicacionCasosDEusos.Models.Configuracion;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Interfaces;
using System.Drawing;

namespace Sales.AplicacionCasosDEusos.Service.Configuracion
{
    public class ConfiguracionService : IConfiguracionService
    {
        private readonly ILogger<ConfiguracionService> logger;
        private readonly IConfiguracionRepository configuracionRepository;
        public ConfiguracionService(ILogger<ConfiguracionService> logger,
                                    IConfiguracionRepository configuracionRepository)
        {
            this.logger = logger;
            this.configuracionRepository = configuracionRepository;
        }
        public ServiceResult<ConfiguracionGetModel> GetConfiguracion(int configuracionId)
        {
            throw new NotImplementedException();
        }

        public global::ServiceResult<List<ConfiguracionGetModel>> GetConfiguraciones()
        {
            throw new NotImplementedException();
        }

        public global::ServiceResult<ConfiguracionGetModel> RemoveConfiguracion(ConfiguracionRemoveDto configuracionDto)
        {
            throw new NotImplementedException();
        }

        public global::ServiceResult<ConfiguracionGetModel> SaveConfiguracion(ConfiguracionDto configuracionDto)
        {
            throw new NotImplementedException();
        }

        public global::ServiceResult<ConfiguracionGetModel> UpdateConfiguracion(ConfiguracionUpdateDto configuracionDto)
        {
            throw new NotImplementedException();
        }

        global::ServiceResult<ConfiguracionGetModel> IConfiguracionService.GetConfiguracion(int configuracionId)
        {
            throw new NotImplementedException();
        }
    }
}


    
