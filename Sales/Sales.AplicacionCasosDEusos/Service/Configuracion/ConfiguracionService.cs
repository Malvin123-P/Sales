

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
            ServiceResult<ConfiguracionGetModel> result = new ServiceResult<ConfiguracionGetModel>();
            try
            {
                var configuracion = configuracionRepository.GetEntity(configuracionId);

                result.Data = new ConfiguracionGetModel()
                {
                    recurso = configuracion.Recurso,
                    propiedad = configuracion.Propiedad,
                    valor = configuracion.Valor,
                };
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo la configuracion";
                logger.LogError(result.Message, ex.ToString());
            }
        }
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

    public ServiceResult<ConfiguracionGetModel> RemoveConfiguracion(ConfiguracionRemoveDto configuracionRemoveDto)
    {
        ServiceResult<ConfiguracionGetModel> result = new ServiceResult<ConfiguracionGetModel>();

        try
        {
            this.configuracionRepository.Remove(new Configuracion()
            {
                Recurso = configuracionRemoveDto.recurso,
                Propiedad = configuracionRemoveDto.propiedad,
                Valor = configuracionRemoveDto.valor,
            });
        }
        catch (Exception ex)
        {

            result.Success = false;
            result.Message = "Error obteniendo el autor";
            this.logger.LogError(result.Message, ex.ToString());
        }
    }

    public ServiceResult<ConfiguracionGetModel> SaveConfiguracion(ConfiguracionUpdateDto configuracionDto)
    {
        if (string.IsNullOrEmpty(configuracionDto.recurso))
        {
            result.Success = false;
            result.Message = "El recurso es requerido";
            return result;
        }
        if (authorDto.state.Length > 50)
        {
            result.Success = false;
            result.Message = "El recurso debe tener 50 caracteres.";
            return result;
        }
        if (string.IsNullOrEmpty(configuracionDto.propiedad))
        {
            result.Success = false;
            result.Message = "La propiedad es requerida";
            return result;
        }
        if (authorDto.state.Length > 50)
        {
            result.Success = false;
            result.Message = "La propiedad debe tener 20 caracteres.";
            return result;
        }
        if (string.IsNullOrEmpty(configuracionDto.valor))
        {
            result.Success = false;
            result.Message = "El valor es requerida";
            return result;
        }
        if (authorDto.state.Length > 60)
        {
            result.Success = false;
            result.Message = "El codigo postal debe tener 5 caracteres.";
            return result;
        }
        this.configuracionRepository.Save(new Dominio.Entities.Configuracion()
        {
            Recurso = configuracionDto.recurso,
            Propiedad = configuracionDto.propiedad,
            Valor = configuracionDto.valor,
        });
        catch (Exception ex)
            {

            result.Success = false;
            result.Message = "Error guardando la configuracion";
            this.logger.LogError(result.Message, ex.ToString());
        }



        public class ServiceResult<ConfiguracionGetModel> UpdateConfiguracion(ConfiguracionDto configuracionUpdateDto)
        {
            ServiceResult<ConfiguracionGetModel> result = new ServiceResult<ConfiguracionGetModel>();

            try
            {
                if (string.IsNullOrEmpty(configuracionUpdateDto.recurso))
                {
                    result.Success = false;
                    result.Message = "La configuracion es requerido";
                    return result;
                }
                if (configuracionUpdateDto.recurso.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El recurso debe tener 50 caracteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(configuracionUpdateDto.propiedad))
                {
                    result.Success = false;
                    result.Message = "La propiedad es requerida";
                    return result;
                }
                if (authorUpdateDto.propiedad.Length > 50)
                {
                    result.Success = false;
                    result.Message = "La propiedad debe tener 40 caracteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(configuracionUpdateDto.propiedad))
                {
                    result.Success = false;
                    result.Message = "El estado es requerido";
                    return result;
                }
                if (configuracionUpdateDto.propiedad.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El estado debe tener 50 caracteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(configuracionUpdateDto.valor))
                {
                    result.Success = false;
                    result.Message = "La ciudad es requerida";
                    return result;
                }
                if (configuracionUpdateDto.valor.Length > 60)
                {
                    result.Success = false;
                    result.Message = "La ciudad debe tener 60 caracteres.";
                    return result;
                }
                
                }
                configuracionRepository.Save(new Dominio.Entities.Configuracion()
                {
                    Recurso = configuracionUpdateDto.recurso,
                    Propiedad = configuracionUpdateDto.propiedad,
                    Valor = configuracionUpdateDto.valor,
                });
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el autor";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
    }
}
