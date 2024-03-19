
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Rol;
using Sales.AplicacionCasosDEusos.Models.Rol;
namespace Sales.AplicacionCasosDEusos.Contract
{
    public interface IRolService
    {
        ServiceResult<List<RolGetModel>> GetRols();
        ServiceResult<RolGetModel> GetRol(int rolId);

        ServiceResult<RolGetModel> SaveRol(RolDto rolDto);

        ServiceResult<RolGetModel> UpdateRol(RolUpdateDto rolDto);

        ServiceResult<RolGetModel> RemoveRol(RolRemoveDto rolDto);
    }
}
