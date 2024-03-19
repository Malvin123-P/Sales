using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Negocio;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AplicacionCasosDEusos.Contracts
{
    public interface INegocioService
    {
        ServiceResult<List<NegocioGetMoldels>> GetNegocio();
        ServiceResult<NegocioGetMoldels> GetNegocio(int Id);
        ServiceResult<NegocioGetMoldels> SaveNegocio(NegocioAddDto negocioAddDto);
        ServiceResult<NegocioGetMoldels> UpdateNegocio(NegocioAddDto negocioAddDto);
        ServiceResult<NegocioGetMoldels> DeleteNegocio(NegocioAddDto negocioAddDto);
    }
}
