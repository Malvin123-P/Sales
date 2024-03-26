using Sales.AplicacionCasosDEusos.DtosCasosUsos.DetalleVenta;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.DetalleVenta;



namespace Sales.AplicacionCasosDEusos.Contracts
{
    public interface IDetalleVentaService
    {
        ServiceResult<List<DetalleVentaGetModels>> GetDetalleVenta();
        ServiceResult<DetalleVentaGetModels> GetDetalleVenta(int Id);
        ServiceResult<DetalleVentaGetModels> SaveDetalleVenta(DetalleVentaAddDto detalleVentaAddDto);
        ServiceResult<DetalleVentaGetModels> UpdateDetalleVenta(DetalleVentaUpdateDto detalleVentaUpdateDto);
        ServiceResult<DetalleVentaGetModels> DeleteDetalleVenta(DetalleVentaDeleteDto detalleVentaDeleteDto);

    }
}
