using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contract.Rol;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Rol;
using Sales.AplicacionCasosDEusos.Dtos.Enums;
using Sales.AplicacionCasosDEusos.Dtos.Rol;
using Sales.AplicacionCasosDEusos.Dtos.Rol;
using Sales.AplicacionCasosDEusos.Dtos.Rol;
using Sales.AplicacionCasosDEusos.Models.Rol;
using Sales.AplicacionCasosDEusos.Models.Rol;
using Sales.AplicacionCasosDEusos.Service.Rol;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Repositories;

namespace Sales.AplicacionCasosDEusos.Service.Author
{
    internal class RolNewService : IRolNewService
    {
        private readonly ILogger<RolService> logger;
        private readonly IRolRepository rolRepository;

        public RolNewService(ILogger<RolService> logger,
                                    IRolRepository rolRepository) 
        {
            this.logger = logger;
            this.rolRepository = rolRepository;
        }
        public ServiceResult<RolGetModel> Get(int rolId)
        {
            public ServiceResult<RolGetModel> GetRol(int rolId)
            {
                ServiceResult<RolGetModel> result = new ServiceResult<RolGetModel>();
                try
                {
                    var rol = rolRepository.GetEntity(rolId);

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
                    logger.LogError(result.Message, ex.ToString());
                }

                return result;
            }

        public ServiceResult<List<RolGetModel>> GetAll()
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
        }

        public ServiceResult<RolGetModel> Remove(RolRemoveDto rolsRemoveDto)
        {
            ServiceResult<RolGetModel> result = new ServiceResult<RolGetModel>();

            try
            {
                this.rolRepository.Remove(new ()
                {
                    Descripcion = rolsRemoveDto.Descripcion,
                    EsActivo = rolsRemoveDto.EsActivo,
                    IdUsuario = rolsRemoveDto.IdUsuario,
                    FechaEliminar = rolsRemoveDto.FechaEliminar,
                });
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo el rol";
                this.logger.LogError(result.Message, ex.ToString());
            }
        }
    }

        public ServiceResult<RolGetModel> Save(RolDto rolDto)
        {
        ServiceResult<AuthorGetModel> result = new Service<AuthorGetModel>();
        try
        { 
            var resultIsValid = this.IsValid(rolDto);

        if (string.IsNullOrEmpty(rolDto.Descripcion))
        {
            result.Success = false;
            result.Message = "La descripcion es requerida";
            return result;
        }
        if (authorDto.state.Length > 30)
        {
            result.Success = false;
            result.Message = "El recurso debe tener 30 caracteres.";
            return result;
        
        }
        this.rolRepository.Save(new Dominio.Entities.Rol()
        {
            Descripcion = rolDto.Descripcion,
            EsActivo = rolDto.EsActivo,
            IdUsuario = rolDto.IdUsuario,
            FechaEliminar = rolDto.FechaEliminar,
        });
        catch (Exception ex)
            {

            result.Success = false;
            result.Message = "Error guardando la configuracion";
            this.logger.LogError(result.Message, ex.ToString());
        }
    }

        public ServiceResult<RolGetModel> Update(RolUpdateDto rolUpdateDto)
        {
        ServiceResult<RolGetModel> result = new ServiceResult<RolGetModel>();

        try
        {
            var resultIsValid = this.Isvalid(rolUpdateDto, DtoAction.Save);

            if (!resultIsValid.Success)
            {
                result.Message = resultIsValid.Message;
            }
            this.rolRepository.Save(new Dominio.Entities.Rol()
                {
                    Descripcion = rolUpdateDto.Descripcion,
                    EsActivo = rolUpdateDto.EsActivo,
                    IdUsuario = rolUpdateDto.IdUsuario,
                    FechaEliminar = rolUpdateDto.FechaEliminar,
                });
    }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el rol";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        }
    private ServiceResult<string> IsValid(RolDtoBase rolsDtoBase, DtoAction action)
{
    ServiceResult<string> result = new ServiceResult<string>();

    if (string.IsNullOrEmpty(rolDto.Descripcion))
    {
        result.Success = false;
        result.Message = "La descripcion es requerida";
        return result;
    }
    if (authorDto.state.Length > 30)
    {
        result.Success = false;
        result.Message = "El recurso debe tener 30 caracteres.";
        return result;

    }
    if (action == DtoAction.Save)
    {
        if (this.rolRepository.Exists(ca => ca.rolname == rolDtoBase.Descripcion))
        {
            result.Success = false;
            result.Message = $"El rol {rolDtoBase.Phone} ya existe.";
        }
        return result;

    }
}

