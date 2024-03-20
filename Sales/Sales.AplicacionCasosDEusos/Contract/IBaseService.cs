using Sales.AplicacionCasosDEusos.Core;


namespace Sales.AplicacionCasosDEusos.Contract
{
    public interface IBaseService<TDtoAdd, TDtoUpdate, TDtoRemove, TModel>
    {
        ServiceResult<List<TModel>> GetAll();
        ServiceResult<TModel> Get(int authorId);
        ServiceResult<TModel> Save(TDtoAdd authorDto);

        ServiceResult<TModel> Update(TDtoUpdate authorsUpdateDto);

        ServiceResult<TModel> Remove(TDtoRemove authorsRemoveDto);
    }
}
