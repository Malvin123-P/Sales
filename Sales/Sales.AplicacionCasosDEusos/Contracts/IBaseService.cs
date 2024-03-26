using Sales.AplicacionCasosDEusos.Core;

namespace Sales.AplicacionCasosDEusos.Contracts
{
    public interface IBaseService<TDoAdd,TDoUpdate,TDtoDelete,TModel>
    {
        ServiceResult<List<TModel>> GetAll();
        ServiceResult<TModel> Get(int Id);
        ServiceResult<TModel> Save(TDoAdd detalleVentaAddDto);
        ServiceResult<TModel> Update(TDoUpdate detalleVentaUpdateDto);
        ServiceResult<TModel> Delete(TDtoDelete detalleVentaDeleteDto);
    }
}
