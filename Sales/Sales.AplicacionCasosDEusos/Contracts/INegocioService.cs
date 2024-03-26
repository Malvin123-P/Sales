using Sales.AplicacionCasosDEusos.DtosCasosUsos.Negocio;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.Negocio;


namespace Sales.AplicacionCasosDEusos.Contracts
{
    public interface INegocioService
    {
        ServiceResult<List<NegocioGetMoldels>> GetNegocio();
        ServiceResult<NegocioGetMoldels> GetNegocio(int Id);
        ServiceResult<NegocioGetMoldels> SaveNegocio(NegocioAddDto negocioAddDto);
        ServiceResult<NegocioGetMoldels> UpdateNegocio(NegocioUpdateDto negocioUpdateDto);
        ServiceResult<NegocioGetMoldels> DeleteNegocio(NegocioDeleteDto negocioDeleteDto);
    }
}
