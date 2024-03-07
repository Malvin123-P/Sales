using Sales.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Interfaces;

namespace Sales.Infraestructura.Repositories
{
    public class TipoDocumentoVentaRepository : ITipoDocumentoVentaRepository
    {
        private readonly SalesContext context;

        public TipoDocumentoVentaRepository(SalesContext context)
        {
            this.context = context;
        }

        public void Create(TipoDocumentoVenta tipoDocumentoVenta)
        {
            try
            {
                // Check for existing code (optional)
                if (context.TipoDocumentosVenta.Any(t => t.Id == tipoDocumentoVenta.Id))
                {
                     throw new TipoDocumentoVentaException("Ya existe un tipo de documento con el id ingresado.");
                }

                this.context.TipoDocumentosVenta.Add(tipoDocumentoVenta);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new TipoDocumentoVentaException("Error al crear el tipo de documento", ex);
            }
        }

        public TipoDocumentoVenta GetTipoDocumento(int tipoDocumentId)
        {
            return this.context.TipoDocumentosVenta.Find(tipoDocumentId);
        }

        public List<TipoDocumentoVenta> GetTipoDocumentoVentas()
        {
            return this.context.TipoDocumentosVenta.ToList();
        }

        public void Remove(TipoDocumentoVenta tipoDocumentoVenta)
        {
            try
            {
                TipoDocumentoVenta documentToRemove = this.GetTipoDocumento(tipoDocumentoVenta.Id);

                if (documentToRemove == null)
                {
                    throw new TipoDocumentoVentaException("El tipo de documento no existe");
                }

                this.context.TipoDocumentosVenta.Remove(documentToRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new TipoDocumentoVentaException("Error al eliminar el tipo de documento", ex);
            }
        }

        public void Update(TipoDocumentoVenta tipoDocumentoVenta)
        {
            try
            {
                TipoDocumentoVenta documentToUpdate = this.GetTipoDocumento(tipoDocumentoVenta.Id);

                if (documentToUpdate == null)
                {
                    throw new TipoDocumentoVentaException("El tipo de documento no existe");
                }

                documentToUpdate.Descripcion = tipoDocumentoVenta.Descripcion;
                documentToUpdate.FechaMod = tipoDocumentoVenta.FechaMod;
                documentToUpdate.IdUsuarioMod = tipoDocumentoVenta.IdUsuarioMod;
                documentToUpdate.EsActivo = tipoDocumentoVenta.EsActivo;

                this.context.TipoDocumentosVenta.Update(documentToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new TipoDocumentoVentaException("Error al actualizar el tipo de documento", ex);
            }
        }
    }
}
