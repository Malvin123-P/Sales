using Sales.AplicacionCasosDEusos.DtosCasosUsos.Negocio;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.Negocio;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Emun;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Menu;


namespace Sales.AplicacionCasosDEusos.Contracts
{
    public interface INegocioService:IBaseService<NegocioAddDto, NegocioUpdateDto, NegocioDeleteDto, NegocioGetMoldels>
    {
        ServiceResult<string> IsValid(NegocioBaseDto menuBaseDto, DtoAction dtoAction);
    }
}
