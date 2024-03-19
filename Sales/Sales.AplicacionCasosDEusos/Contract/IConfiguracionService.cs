using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Configuracion;
using Sales.AplicacionCasosDEusos.Models.Configuracion;

namespace Sales.AplicacionCasosDEusos.Contract
{
    public interface IConfiguracionService
    {
        ServiceResult<List<ConfiguracionGetModel>> GetConfiguraciones();
        ServiceResult<ConfiguracionGetModel> GetConfiguracion(int configuracionId);

        ServiceResult<ConfiguracionGetModel> SaveConfiguracion(ConfiguracionDto configuracionDto);

        ServiceResult<ConfiguracionGetModel> UpdateConfiguracion(ConfiguracionUpdateDto configuracionDto);

        ServiceResult<ConfiguracionGetModel> RemoveConfiguracion(ConfiguracionRemoveDto configuracionDto);
    }
}
