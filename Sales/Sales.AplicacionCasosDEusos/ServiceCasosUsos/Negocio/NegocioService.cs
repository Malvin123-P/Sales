using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.Negocio;
using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Negocio;
using Sales.Infraestructura.Interfaces;
using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.DetalleVenta;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Emun;


namespace Sales.AplicacionCasosDEusos.ServiceCasosUsos.Negocio
{
    public class NegocioService :INegocioService
    {
        private readonly ILogger<NegocioService> logger;
        private readonly INegocioRepository negocioRepository;

        public NegocioService(ILogger<NegocioService> logger, INegocioRepository negocioRepository)
        {
            this.logger = logger;
            this.negocioRepository = negocioRepository;
        }
    
        public ServiceResult<List<NegocioGetMoldels>> GetAll()
        {
            ServiceResult<List<NegocioGetMoldels>> result = new ServiceResult<List<NegocioGetMoldels>>();
           
            try
            {
               result.Data = this.negocioRepository.GetEntities().Select(ne => new NegocioGetMoldels()
                {
                    Id = ne.Id,
                    UrlLogo = ne.UrlLogo,
                    NombreLogo = ne.NombreLogo,
                    NumeroDocumento = ne.NumeroDocumento,
                    Nombre = ne.Nombre,
                    Correo = ne.Correo,
                    Direccion = ne.Direccion,
                    Telefono = ne.Telefono,
                    SimboloMoneda = ne.SimboloMoneda,
                    PorcentajeImpuesto = ne.PorcentajeImpuesto,
                    FechaRegistro = ne.FechaRegistro,
                    IdUsuarioCreacion = ne.IdUsuarioCreacion

                }).ToList();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "EERROR OBTENIENDO EL NEGOCIO";
                this.logger.LogError(result.Message, ex.ToString);
            }

            return result;
        }

        public ServiceResult<NegocioGetMoldels> Get(int Id)
        {
            ServiceResult<NegocioGetMoldels> result = new ServiceResult<NegocioGetMoldels>();

            try
            {
                var negocio = this.negocioRepository.GetEntity(Id);

                
                result.Data = new NegocioGetMoldels()
                {
                    Id = negocio.Id,
                    UrlLogo = negocio.UrlLogo,
                    NombreLogo = negocio.NombreLogo,
                    NumeroDocumento = negocio.NumeroDocumento,
                    Nombre = negocio.Nombre,
                    Correo = negocio.Correo,
                    Direccion = negocio.Direccion,
                    Telefono = negocio.Telefono,
                    SimboloMoneda = negocio.SimboloMoneda,
                    PorcentajeImpuesto = negocio.PorcentajeImpuesto,
                    FechaRegistro = negocio.FechaRegistro,
                    IdUsuarioCreacion = negocio.IdUsuarioCreacion
                };
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "EERROR OBTENIENDO EL NEGOCIO";
                this.logger.LogError(result.Message, ex.ToString);
            }

            return result;
        }

        public ServiceResult<NegocioGetMoldels> Save(NegocioAddDto negocioAddDto)
        {
            ServiceResult<NegocioGetMoldels> result = new ServiceResult<NegocioGetMoldels>();

            try
            {

                var resultIsVali = this.IsValid(negocioAddDto, DtoAction.Save);

                if (!resultIsVali.Success)
                {
                    result.Message = resultIsVali.Message;
                    return result;
                }

                this.negocioRepository.Save(new Dominio.Entities.Negocio()
                {
                    UrlLogo = negocioAddDto.UrlLogo,
                    NombreLogo = negocioAddDto.NombreLogo,
                    NumeroDocumento = negocioAddDto.NumeroDocumento,
                    Nombre = negocioAddDto.Nombre,
                    Correo = negocioAddDto.Correo,
                    Direccion = negocioAddDto.Direccion,
                    Telefono = negocioAddDto.Telefono,
                    SimboloMoneda = negocioAddDto.SimboloMoneda,
                    PorcentajeImpuesto = negocioAddDto.PorcentajeImpuesto,
                    FechaRegistro = negocioAddDto.FechaRegistro,
                    IdUsuarioCreacion = negocioAddDto.IdUsuarioCreacion
                });
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "EERROR GUARDANDO EL NEGOCIO";
                this.logger.LogError(result.Message, ex.ToString);
            }

            return result;
        }

        public ServiceResult<NegocioGetMoldels> Update(NegocioUpdateDto negocioUpdateDto)
        {
            ServiceResult<NegocioGetMoldels> result = new ServiceResult<NegocioGetMoldels>();

            try
            {

                var resultIsVali = this.IsValid(negocioUpdateDto, DtoAction.Update);

                if (!resultIsVali.Success)
                {
                    result.Message = resultIsVali.Message;
                    return result;
                }

                this.negocioRepository.Update(new Dominio.Entities.Negocio()
                {
                    UrlLogo = negocioUpdateDto.UrlLogo,
                    NombreLogo = negocioUpdateDto.NombreLogo,
                    NumeroDocumento = negocioUpdateDto.NumeroDocumento,
                    Nombre = negocioUpdateDto.Nombre,
                    Correo = negocioUpdateDto.Correo,
                    Direccion = negocioUpdateDto.Direccion,
                    Telefono = negocioUpdateDto.Telefono,
                    SimboloMoneda = negocioUpdateDto.SimboloMoneda,
                    PorcentajeImpuesto = negocioUpdateDto.PorcentajeImpuesto,
                    FechaMod = negocioUpdateDto.FechaMod,
                    IdUsuarioMod = negocioUpdateDto.IdUsuarioMod
                });
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "EERROR ACTUALIZANDO EL NEGOCIO";
                this.logger.LogError(result.Message, ex.ToString);
            }

            return result;
        }

        public ServiceResult<NegocioGetMoldels> Delete(NegocioDeleteDto negocioDeleteDto)
        {
            ServiceResult<NegocioGetMoldels> result = new ServiceResult<NegocioGetMoldels>();
            try
            {
                this.negocioRepository.Delete(new Dominio.Entities.Negocio()
                {
                    Id = negocioDeleteDto.Id,
                    FechaElimino = negocioDeleteDto.FechaElimino,
                    IdUsuarioElimino = negocioDeleteDto.IdUsuarioElimino
                });

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "ERROR BORRANDO EL NEGOCIO";
                this.logger.LogError(result.Message, ex.ToString);
            }
            return result;
        }


        public ServiceResult<string> IsValid(NegocioBaseDto negocioBaseDto, DtoAction dtoAction)
        {
            ServiceResult<string> result = new ServiceResult<string>();

            //Validaciones

            if (dtoAction == DtoAction.Save)
            {
                if (this.negocioRepository.Exists(ne => ne.Id == negocioBaseDto.Id))
                {
                    result.Success = false;
                    result.Message = $"EL NEGOCIO {negocioBaseDto.Id} YA EXISTE.";
                    return result;
                }
            }
            return result;
        }
    }
}
