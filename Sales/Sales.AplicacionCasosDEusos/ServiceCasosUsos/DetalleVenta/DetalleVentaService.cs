using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.DetalleVenta;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.DetalleVenta;
using Sales.AplicacionCasosDEusos.ServiceCasosUsos.Menu;
using Sales.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AplicacionCasosDEusos.ServiceCasosUsos.DetalleVenta
{
    public class DetalleVentaService : IDetalleVentaService
    {
        private readonly ILogger<DetalleVentaService> logger;
        private readonly IDetalleVentaRepository detalleVentaRepository;

        public DetalleVentaService(ILogger<DetalleVentaService> logger, IDetalleVentaRepository detalleVentaRepository)
        {
            this.logger = logger;
            this.detalleVentaRepository = detalleVentaRepository;
        }

        public ServiceResult<DetalleVentaGetModels> DeleteDetalleVenta(DetalleVentaAddDto detalleVentaAddDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<List<DetalleVentaGetModels>> GetDetalleVenta()
        {
            ServiceResult<List<DetalleVentaGetModels>> result = new ServiceResult<List<DetalleVentaGetModels>>();
            return result;
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ServiceResult<DetalleVentaGetModels> GetDetalleVenta(int Id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DetalleVentaGetModels> SaveDetalleVenta(DetalleVentaAddDto detalleVentaAddDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DetalleVentaGetModels> UpdateDetalleVenta(DetalleVentaAddDto detalleVentaAddDto)
        {
            throw new NotImplementedException();
        }
    }
}
