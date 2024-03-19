using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.DetalleVenta;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.DetalleVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AplicacionCasosDEusos.Contracts
{
    public interface IDetalleVentaService
    {
        ServiceResult<List<DetalleVentaGetModels>> GetDetalleVenta();
        ServiceResult<DetalleVentaGetModels> GetDetalleVenta(int Id);
        ServiceResult<DetalleVentaGetModels> SaveDetalleVenta(DetalleVentaAddDto detalleVentaAddDto);
        ServiceResult<DetalleVentaGetModels> UpdateDetalleVenta(DetalleVentaAddDto detalleVentaAddDto);
        ServiceResult<DetalleVentaGetModels> DeleteDetalleVenta(DetalleVentaAddDto detalleVentaAddDto);

    }
}
