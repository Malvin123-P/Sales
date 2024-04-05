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
         throw new NotImplementedException();
        }

        public ServiceResult<List<RolGetModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResult<RolGetModel> Remove(RolRemoveDto rolsRemoveDto)
        {
            ServiceResult<RolGetModel> result = new ServiceResult<RolGetModel>();

            try
            {
                rolRepository.Remove(new ()
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
        throw new NotImplementedException();
    }

        public ServiceResult<RolGetModel> Update(RolUpdateDto rolUpdateDto)
        {
        throw new NotImplementedException();
    }
    private ServiceResult<string> IsValid(RolDtoBase rolsDtoBase, DtoAction action) 
    {
        throw new NotImplementedException();
    }

    
}

