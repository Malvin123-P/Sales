

using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contract;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Configuracion;
using Sales.AplicacionCasosDEusos.Models.Configuracion;
using Sales.Infraestructura.Interfaces;
using System.Drawing;

namespace Sales.AplicacionCasosDEusos.Service
{
    internal class ConfiguracionService : IConfiguracionService
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

        public ServiceResult<List<ConfiguracionGetModel>> GetConfiguraciones()
        {
            ServiceResult<List<ConfiguracionGetModel>> result = new ServiceResult<List<ConfiguracionGetModel>>();

            try
            {
                result.Data = this.configuracionRepository.GetEntities().Select(cd => new ConfiguracionGetModel()
                {
                    recurso = cd.Recurso,
                    propiedad = cd.Propiedad,
                    valor = cd.Valor,
                }).ToList();
            }

            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo los autores";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult<ConfiguracionGetModel> RemoveConfiguracion(ConfiguracionDto configuracionDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<ConfiguracionGetModel> SaveConfiguracion(ConfiguracionDto configuracionDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<ConfiguracionGetModel> UpdateConfiguracion(ConfiguracionDto configuracionDto)
        {
            throw new NotImplementedException();
        }
    }
}
