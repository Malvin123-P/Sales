using Sales.AplicacionCasosDEusos.DtosCasosUsos.DetalleVenta;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.DetalleVenta;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Emun;



namespace Sales.AplicacionCasosDEusos.Contracts
{
    public interface IDetalleVentaService:IBaseService<DetalleVentaAddDto, DetalleVentaUpdateDto, DetalleVentaDeleteDto, DetalleVentaGetModels>
    {
        ServiceResult<string> IsValid(NegocioDtoBase  detalleVentaDtoBase,DtoAction dtoAction);

    }
}
