using Sales.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Interfaces
{
    public interface ITipoDocumentoVentaRepository
    {
        void Create(TipoDocumentoVenta tipoDocumentoVenta);
        void Update(TipoDocumentoVenta tipoDocumentoVenta);
        void Remove(TipoDocumentoVenta tipoDocumentoVenta);
        List<TipoDocumentoVenta> GetTipoDocumentoVentas();
        TipoDocumentoVenta GetTipoDocumento(int tipoDocumentId);
    }
}
