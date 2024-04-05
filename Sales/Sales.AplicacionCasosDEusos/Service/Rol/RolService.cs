using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contract.Rol;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Rol;
using Sales.AplicacionCasosDEusos.Dtos.Rol;
using Sales.AplicacionCasosDEusos.Models.Rol;
using Sales.AplicacionCasosDEusos.Models.Rol;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Interfaces;
using Sales.Infraestructura.Repositories;

namespace Sales.AplicacionCasosDEusos.Service.Rol
{
    public class RolService : IRolService
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

        ServiceResult<List<RolGetModel>> IRolService.GetRols()
        {
            throw new NotImplementedException();
        }

        ServiceResult<RolGetModel> IRolService.RemoveRol(RolRemoveDto rolDto)
        {
            throw new NotImplementedException();
        }


        ServiceResult<RolGetModel> IRolService.UpdateRol(RolUpdateDto rolDto)
        {
            throw new NotImplementedException();
        }
    }


   
    }


    
   
