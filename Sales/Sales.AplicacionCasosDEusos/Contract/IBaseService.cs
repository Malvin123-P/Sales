using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Configuracion;
using Sales.AplicacionCasosDEusos.Models.Author;
using Sales.AplicacionCasosDEusos.Models.Configuracion;


namespace Sales.AplicacionCasosDEusos.Contract
{
    public interface IBaseService<TDtoAdd, TDtoUpdate, TDtoRemove, TModel>
    {
        ServiceResult<List<TModel>> GetAll();
        ServiceResult<TModel> Get(int authorId, int configuracionId);
        ServiceResult<TModel> Save(TDtoAdd authorDto, TDtoAdd configuracionDto);

        ServiceResult<TModel> Update(TDtoUpdate authorsUpdateDto, TDtoUpdate configuracionUpdateDto);

        ServiceResult<TModel> Remove(TDtoRemove authorsRemoveDto, TDtoRemove configuracionRemoveDto);


    }
}
