using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contract;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Configuracion;
using Sales.AplicacionCasosDEusos.Models.Configuracion;
using Sales.Application.Core;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Application.Service
{
    public class ConfiguracionNewService : IConfiguracionService
    {
        private readonly ILogger<ConfiguracionNewService> logger;
        private readonly IConfiguracionRepository categoryRepository;

        public ConfiguracionNewService(ILogger<ConfiguracionNewService> logger,
                               IConfiguracionRepository configuracionRepository)
        {
            this.logger = logger;
            this.configuracionRepository = configuracionRepository;
        }

        public ServicesResult<ConfiguracionGetModel> Get(int Id)
        {
            ServicesResult<ConfiguracionGetModel> result = new ServicesResult<ConfiguracionGetModel>();

            try
            {
                var configuracion = this.configuracionRepository.GetEntity(Id);

                if (configuracion != null)
                {
                    result.Data = new ConfiguracionGetModel
                    {
                        recurso = configuracion.recurso,
                        propiedad = configuracion.propiedad,
                        valor = configuracion.valor,
                    };
                }
                else
                {
                    result.Success = false;
                    result.Message = "La configuracion no existe.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener la configuracion.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;

        }

        public ServicesResult<List<ConfiguracionGetModel>> GetAll()
        {
            ServicesResult<List<ConfiguracionGetModel>> result = new ServicesResult<List>ConfiguracionGetModel>>();

            try
            {
                var configuraciones = this.configuracionRepository.GetEntities().Select(
                    configuracion => new ConfiguracionGetModel()
                    {
                        recurso = configuracion.recurso,
                        propiedad = configuracion.propiedad,
                        valor = configuracion.valor,
                    }).ToList();

                result.Data = configuraciones;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener las configuraciones.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServicesResult<ConfiguracionGetModel> Remove(ConfiguracionRemoveDto RemoveDto)
        {
            ServicesResult<ConfiguracionGetModel> result = new ServicesResult<ConfiguracionGetModel>();

            try
            {
                this.configuracionRepository.Remove(new Configuracion()
                {
                    Recurso = RemoveDto.Recurso,
                    Propiedad = RemoveDto.Propiedad,
                    Valor = RemoveDto.Valor,
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar la configuracion.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServicesResult<ConfiguracionGetModel> Save(ConfiguracionDtoAdd AddDto)
        {
            ServicesResult<ConfiguracionGetModel> result = new ServicesResult<ConfiguracionGetModel>();

            try
            {
                var validationResult = this.IsValid(AddDto, DtoAction.Save);

                if (!validationResult.Success)
                {
                    result.Message = validationResult.Message;
                    result.Success = validationResult.Success;
                    return result;
                }

                this.categoryRepository.Save(new Configuracion()
                {
                    Recurso = AddDto.Recurso,
                    Propiedad = AddDto.Propiedad,
                    Valor = AddDto.Valor,
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar la configuracion.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServicesResult<ConfiguracionGetModel> Update(ConfiguracionDtoUpdate UpdateDto)
        {
            ServicesResult<ConfiguracionGetModel> result = new ServicesResult<ConfiguracionGetModel>();

            try
            {
                var validationResult = this.IsValid(UpdateDto, DtoAction.Update);

                if (!validationResult.Success)
                {
                    result.Success = result.Success;
                    result.Message = validationResult.Message;
                    return result;
                }

                var configuracion = this.configuracionRepository.GetEntity(UpdateDto.Recurso);

                if (configuracion == null)
                {
                    result.Success = false;
                    result.Message = "La configuracion no existe.";
                    return result;
                }

                configuracion.Recurso = UpdateDto.Recurso;
                configuracion.Propiedad = UpdateDto.Propiedad;
                configuracion.Valor = UpdateDto.Valor;

                this.configuracionRepository.Update(configuracion);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar la configuracion.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        private ServicesResult<string> IsValid(ConfiguracionDtoBase configuracionDtoBase, DtoAction action)
        {
            ServicesResult<string> result = new ServicesResult<string>();

            if (string.IsNullOrEmpty(configuracionDtoBase.Recurso))
            {
                result.Success = false;
                result.Message = "El recurso de la configuracion es requerido.";
                return result;
            }

            if (configuracionDtoBase.Recurso.Length > 15)
            {
                result.Success = false;
                result.Message = "La propiedad de la configuracion debe tener máximo 15 caracteres.";
                return result;
            }

            if (string.IsNullOrEmpty(configuracionDtoBase.Valor))
            {
                result.Success = false;
                result.Message = "La descripción de la configuracion es requerida.";
                return result;
            }

            if (configuracionDtoBase.Valor.Length > 200)
            {
                result.Success = false;
                result.Message = "La descripción de la configuracion debe tener máximo 200 caracteres.";
                return result;
            }

            if (this.configuracionRepository.Exists(ca => ca.Recurso == configuracionDtoBase.Recurso))
            {
                result.Success = false;
                result.Message = $"La configuracion {configuracionDtoBase.Recurso} ya existe.";
                return result;
            }

            return result;
        }
    }
}



