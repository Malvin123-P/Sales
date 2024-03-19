using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contract;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Author;
using Sales.AplicacionCasosDEusos.Dtos.Rol;
using Sales.AplicacionCasosDEusos.Models.Configuracion;
using Sales.AplicacionCasosDEusos.Models.Rol;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Interfaces;

namespace Sales.AplicacionCasosDEusos.Service
{
    internal class RolService : IRolService
    {
        private readonly ILogger<RolService> logger;
        private readonly IRolRepository rolRepository;
        public RolService(ILogger<RolService> logger,
                                    IRolRepository rolRepository)
        {
            this.logger = logger;
            this.rolRepository = rolRepository;
        }
        public ServiceResult<RolGetModel> GetRol(int rolId)
        {
                ServiceResult<RolGetModel> result = new ServiceResult<RolGetModel>();
                try
                {
                    var rol = this.rolRepository.GetEntity(rolId);

                    result.Data = new RolGetModel()
                    {
                        Descripcion = rol.Descripcion,
                        EsActivo = rol.EsActivo,
                        IdUsuario = rol.IdUsuario,
                        FechaEliminar = rol.FechaEliminar,
                    };
                }
                catch (Exception ex)
                {

                    result.Success = false;
                    result.Message = "Error obteniendo el rol";
                    this.logger.LogError(result.Message, ex.ToString());
                }
            }
        }

        public ServiceResult<List<RolGetModel>> GetRols()
        {
            ServiceResult<List<RolGetModel>> result = new ServiceResult<List<RolGetModel>>();
            try
            {
                result.Data = this.rolRepository.GetEntities().Select(cd => new RolGetModel()
                {
                    Descripcion = cd.Descripcion,
                    EsActivo = cd.EsActivo,
                    IdUsuario = cd.IdUsuario,
                    FechaEliminar = cd.FechaEliminar,
                }).ToList();
            }
            catch (Exception ex)
            { 

                result.Success = false;
                result.Message = "Error obteniendo los roles";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }


        public ServiceResult<RolGetModel> RemoveRol(RolDto rolDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<RolGetModel> SaveRol(RolDto rolDto)
        {
        ServiceResult<RolGetModel> result = new ServiceResult<RolGetModel>();

        try
        {
            if (string.IsNullOrEmpty(rolDto.Descripcion))
            {
                result.Success = false;
                result.Message = "La descripcion del rol es requerido";
                return result;
            }
            if (rolDto.IdUsuario.Length > 30)
            {
                result.Success = false;
                result.Message = "Rol debe tener 30 caracteres.";
                return result;
            }
            this.rolRepository.Save(new Dominio.Entities.Rol()
            {
                EsActivo = rolDto.EsActivo,
                FechaRegistro = rolDto.FechaRegistro,
                IdUsuario = rolDto.IdUsuario,
                FechaEliminar = rolDto.FechaEliminar,
                IdUsuarioEliminar = rolDto.IdUsuarioEliminar,
            });
        }
        catch (Exception ex)
        {

            result.Success = false;
            result.Message = "Error guardando el autor";
            this.logger.LogError(result.Message, ex.ToString());
        }



        return result;
    }
}

        public ServiceResult<RolGetModel> UpdateRol(RolDto rolDto)
        {
            throw new NotImplementedException();
        }
    }
}
