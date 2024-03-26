using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.DetalleVenta;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.DetalleVenta;
using Sales.Infraestructura.Interfaces;


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

        public ServiceResult<List<DetalleVentaGetModels>> GetDetalleVenta()
        {
            ServiceResult<List<DetalleVentaGetModels>> result = new ServiceResult<List<DetalleVentaGetModels>>();
            
            try
            {
                result.Data = this.detalleVentaRepository.GetEntities().Select(de => new DetalleVentaGetModels() 
                {
                    Id = de.Id,
                    IdProducto = de.IdProducto,
                    MarcaProducto = de.MarcaProducto,
                    DescripcionProducto = de.DescripcionProducto,
                    CategoriaProducto = de.CategoriaProducto,
                    Cantidad = de.Cantidad,
                    Precio = de.Precio,
                    Total = de.Total,
                    FechaRegistro = de.FechaRegistro,
                    IdUsuarioCreacion = de.IdUsuarioCreacion

                }).ToList();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "ERROR OBTENIENDO EL DETALLE DE LA VENTA";
                this.logger.LogError(result.Message, ex.ToString);
            }

            return result;
        }

        public ServiceResult<DetalleVentaGetModels> GetDetalleVenta(int Id)
        {
            ServiceResult<DetalleVentaGetModels> result = new ServiceResult<DetalleVentaGetModels>();

            try
            {
                var detalleVenta = this.detalleVentaRepository.GetEntity(Id);


                result.Data = new DetalleVentaGetModels()
                {
                    Id = detalleVenta.Id,
                    IdProducto = detalleVenta.IdProducto,
                    MarcaProducto = detalleVenta.MarcaProducto,
                    DescripcionProducto = detalleVenta.DescripcionProducto,
                    CategoriaProducto = detalleVenta.CategoriaProducto,
                    Cantidad = detalleVenta.Cantidad,
                    Precio = detalleVenta.Precio,
                    Total = detalleVenta.Total,
                    FechaRegistro = detalleVenta.FechaRegistro,
                    IdUsuarioCreacion = detalleVenta.IdUsuarioCreacion
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

        public ServiceResult<DetalleVentaGetModels> SaveDetalleVenta(DetalleVentaAddDto detalleVentaAddDto)
        {
            ServiceResult<DetalleVentaGetModels> result = new ServiceResult<DetalleVentaGetModels>();

            try
            {
                //Validaciones
                if (this.detalleVentaRepository.Exists(de => de.Id == detalleVentaAddDto.Id))
                {
                    result.Success = false;
                    result.Message = $"EL DETALLE {detalleVentaAddDto.Id} YA EXISTE.";
                    return result;
                }


                this.detalleVentaRepository.Save(new Dominio.Entities.DetalleVenta()
                {
                    IdProducto = detalleVentaAddDto.IdProducto,
                    MarcaProducto = detalleVentaAddDto.MarcaProducto,
                    DescripcionProducto = detalleVentaAddDto.DescripcionProducto,
                    CategoriaProducto = detalleVentaAddDto.CategoriaProducto,
                    Cantidad = detalleVentaAddDto.Cantidad,
                    Precio = detalleVentaAddDto.Precio,
                    Total = detalleVentaAddDto.Total,
                    FechaRegistro = detalleVentaAddDto.FechaRegistro,
                    IdUsuarioCreacion = detalleVentaAddDto.IdUsuarioCreacion
                });
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "EERROR GUARDANDO EL DETALLE VENTA";
                this.logger.LogError(result.Message, ex.ToString);
            }

            return result;
        }

        

        public ServiceResult<DetalleVentaGetModels> UpdateDetalleVenta(DetalleVentaUpdateDto detalleVentaUpdateDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DetalleVentaGetModels> DeleteDetalleVenta(DetalleVentaDeleteDto detalleVentaDeleteDto)
        {
            ServiceResult<DetalleVentaGetModels> result = new ServiceResult<DetalleVentaGetModels>();

            try
            {
                this.detalleVentaRepository.Delete(new Dominio.Entities.DetalleVenta()
                {
                    Id = detalleVentaDeleteDto.Id,
                    FechaElimino = detalleVentaDeleteDto.FechaElimino,
                    IdUsuarioElimino = detalleVentaDeleteDto.IdUsuarioElimino
                });

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "ERROR BORRANDO EL DETALLE VENTA";
                this.logger.LogError(result.Message, ex.ToString);
            }
            return result;
        }

     
    }


        //private static ServiceResult<string> VakidarDatos(DetalleVentaDtoBase DetalleVentaDtoBase)
        //{
        //    ServiceResult<string> result = new ServiceResult<string>();

        //    if (string.(detalleVentaAddDto.))
        //    {

        //        result.Success = false;
        //        result.Message = "EERROR GUARDANDO EL DETALLE VENTA";
              
        //    }

        //    return result;
        //}
    
}
