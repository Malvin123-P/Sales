using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Negocio;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.Negocio;
using Sales.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Sales.AplicacionCasosDEusos.ServiceCasosUsos.Negocio
{
    internal class NegocioService : INegocioService
    {
        private readonly ILogger<NegocioService> logger;
        private readonly INegocioRepository negocioRepository;

        public NegocioService(ILogger<NegocioService> logger, INegocioRepository negocioRepository)
        {
            this.logger = logger;
            this.negocioRepository = negocioRepository;
        }
        public ServiceResult<NegocioGetMoldels> DeleteNegocio(NegocioAddDto negocioAddDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<List<NegocioGetMoldels>> GetNegocio()
        {
            ServiceResult<List<NegocioGetMoldels>> result = new ServiceResult<List<NegocioGetMoldels>>();
            return result;

            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ServiceResult<NegocioGetMoldels> GetNegocio(int Id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<NegocioGetMoldels> SaveNegocio(NegocioAddDto negocioAddDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<NegocioGetMoldels> UpdateNegocio(NegocioAddDto negocioAddDto)
        {
            throw new NotImplementedException();
        }
    }
}
