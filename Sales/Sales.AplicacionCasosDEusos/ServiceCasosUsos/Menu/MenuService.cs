using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Menu;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.Menu;
using Sales.AplicacionCasosDEusos.ServiceCasosUsos.Negocio;
using Sales.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AplicacionCasosDEusos.ServiceCasosUsos.Menu
{
    internal class MenuService : IMenuService
    {
        private readonly ILogger<MenuService> logger;
        private readonly IMenuRepository menuRepository;

        public MenuService(ILogger<MenuService> logger, IMenuRepository menuRepository)
        {
            this.logger = logger;
            this.menuRepository = menuRepository;
        }

        public ServiceResult<MenuGetModels> DeleteMenu(MenuAddDto menuAddDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<List<MenuGetModels>> GetMenu()
        {
            ServiceResult<List<MenuGetModels>> result = new ServiceResult<List<MenuGetModels>>();
            return result;

            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ServiceResult<MenuGetModels> GetMenu(int Id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<MenuGetModels> SaveMenu(MenuAddDto menuAddDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<MenuGetModels> UpdateMenu(MenuAddDto menuAddDto)
        {
            throw new NotImplementedException();
        }
    }
}
