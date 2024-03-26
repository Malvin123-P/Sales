using Sales.AplicacionCasosDEusos.DtosCasosUsos.Menu;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.Menu;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.DetalleVenta;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Emun;


namespace Sales.AplicacionCasosDEusos.Contracts
{
    public interface IMenuService:IBaseService<MenuAddDto, MenuUpdateDto, MenuDeleteDto, MenuGetModels>
    {
        ServiceResult<string> IsValid(MenuBaseDto  menuBaseDto, DtoAction dtoAction);
    }
}
