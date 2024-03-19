using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contract;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Rol;
using Sales.AplicacionCasosDEusos.Models.Configuracion;
using Sales.AplicacionCasosDEusos.Models.Rol;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public ServiceResult<RolGetModel> UpdateRol(RolDto rolDto)
        {
            throw new NotImplementedException();
        }
    }
}
