using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Menu;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AplicacionCasosDEusos.Contracts
{
    public interface IMenuService
    {
        ServiceResult<List<MenuGetModels>> GetMenu();
        ServiceResult<MenuGetModels> GetMenu(int Id);
        ServiceResult<MenuGetModels> SaveMenu(MenuAddDto menuAddDto);
        ServiceResult<MenuGetModels> UpdateMenu(MenuAddDto menuAddDto);
        ServiceResult<MenuGetModels> DeleteMenu(MenuAddDto menuAddDto);
    }
}
