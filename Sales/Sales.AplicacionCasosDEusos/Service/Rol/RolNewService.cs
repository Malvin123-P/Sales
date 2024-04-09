using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contract;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Rol;
using Sales.AplicacionCasosDEusos.Models.Rol;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Sales.Application.Service
{
    public class RolNewService : IRolService
    {
        private readonly ILogger<RolNewService> logger;
        private readonly IRolRepository rolRepository;

        public RolNewService(ILogger<RolNewService> logger,
                               IRolRepository rolRepository)
        {
            this.logger = logger;
            this.rolRepository = rolRepository;
        }

        public ServicesResult<RolGetModel> Get(int Id)
        {
            ServicesResult<RolGetModel> result = new ServicesResult<RolGetModel>();

            try
            {
                var rol = this.rolRepository.GetEntity(Id);

                if (rol != null)
                {
                    result.Data = new RolGetModel
                    {
                        FechaEliminar = rol.FechaEliminar,
                        IdUsuario = rol.IdUsuario,
                        EsActivo = rol.EsActivo,
                        Descripcion = rol.Descripcion,
                    };
                }
                else
                {
                    result.Success = false;
                    result.Message = "El rol no existe.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener el rol.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;

        }

        public ServicesResult<List<RolGetModel>> GetAll()
        {
            ServicesResult<List<RolGetModel>> result = new ServicesResult<List<RolGetModel>>();

            try
            {
                var roles = this.rolRepository.GetEntities().Select(
                    rol => new RolGetModel()
                    {
                        FechaEliminar = rol.FechaEliminar,
                        IdUsuario = rol.IdUsuario,
                        EsActivo = rol.EsActivo,
                        Descripcion = rol.Descripcion,
                    }).ToList();

                result.Data = roles;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los roles.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServicesResult<RolGetModel> Remove(RolRemoveDto RemoveDto)
        {
            ServicesResult<RolGetModel> result = new ServicesResult<RolGetModel>();

            try
            {
                this.rolRepository.Remove(new Rol()
                {
                    IdUsuario = RemoveDto.IdUsario,
                    Descripcion = RemoveDto.Descripcion,
                    FechaElimino = RemoveDto.ChangeDate
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar el rol.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServicesResult<RolGetModel> Save(RolDtoAdd AddDto)
        {
            ServicesResult<RolGetModel> result = new ServicesResult<RolGetModel>();

            try
            {
                var validationResult = this.IsValid(AddDto, DtoAction.Save);

                if (!validationResult.Success)
                {
                    result.Message = validationResult.Message;
                    result.Success = validationResult.Success;
                    return result;
                }

                this.rolRepository.Save(new Rol()
                {
                    FechaEliminar = AddDto.FechaEliminar,
                    IdUsuario = AddDto.IdUsuario,
                    EsActivo = AddDto.EsActivo,
                    Descripcion = AddDto.Descripcion,
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el rol.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServicesResult<RolGetModel> Update(RolDtoUpdate UpdateDto)
        {
            ServicesResult<RolGetModel> result = new ServicesResult<RolGetModel>();

            try
            {
                var validationResult = this.IsValid(UpdateDto, DtoAction.Update);

                if (!validationResult.Success)
                {
                    result.Success = result.Success;
                    result.Message = validationResult.Message;
                    return result;
                }

                var rol = this.rolRepository.GetEntity(UpdateDto.FechaEliminar);

                if (rol == null)
                {
                    result.Success = false;
                    result.Message = "El rol no existe.";
                    return result;
                }

                rol.FechaEliminar = UpdateDto.FechaEliminar;
                rol.IdUsuario = UpdateDto.IdUsuario;
                rol.EsActivo = UpdateDto.EsActivo;
                rol.Descripcion = UpdateDto.Descripcion;

                this.rolRepository.Update(rol);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el rol.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        private ServicesResult<string> IsValid(RolDtoBase rolDtoBase, DtoAction action)
        {
            ServicesResult<string> result = new ServicesResult<string>();

            if (string.IsNullOrEmpty(rolDtoBase.IdUsuario))
            {
                result.Success = false;
                result.Message = "El ID de la categoría es requerido.";
                return result;
            }

            if (rolDtoBase.IdUsuario.Length > 15)
            {
                result.Success = false;
                result.Message = "El ID del rol debe tener máximo 15 caracteres.";
                return result;
            }

            if (string.IsNullOrEmpty(rolDtoBase.Descripcion))
            {
                result.Success = false;
                result.Message = "La descripción del rol es requerida.";
                return result;
            }

            if (rolDtoBase.Description.Length > 200)
            {
                result.Success = false;
                result.Message = "La descripción del rol debe tener máximo 200 caracteres.";
                return result;
            }

            if (this.rolRepository.Exists(ca => ca.EsActivo == rolDtoBase.EsActivo))
            {
                result.Success = false;
                result.Message = $"El rol {rolDtoBase.Name} ya existe.";
                return result;
            }

            return result;
        }
    }
}

