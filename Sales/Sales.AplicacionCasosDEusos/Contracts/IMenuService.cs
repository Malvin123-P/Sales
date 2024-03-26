using Sales.AplicacionCasosDEusos.DtosCasosUsos.Menu;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.Menu;


namespace Sales.AplicacionCasosDEusos.Contracts
{
    public interface IMenuService
    {
        ServiceResult<List<MenuGetModels>> GetMenu();
        ServiceResult<MenuGetModels> GetMenu(int Id);
        ServiceResult<MenuGetModels> SaveMenu(MenuAddDto menuAddDto);
        ServiceResult<MenuGetModels> UpdateMenu(MenuUpdateDto menuUpdateDto);
        ServiceResult<MenuGetModels> DeleteMenu(MenuDeleteDto menuDeleteDto);
    }
}
