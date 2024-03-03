using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editorial.Dominio.Entities;
using Sales.Dominio.Entities;

namespace Sales.Infraestructura.Interfaces
{
    public interface IDetalleVentaRepository
    {
        void Create(DetalleVenta DetalleVenta);
        void Update(DetalleVenta DetalleVenta);
        void Remove(DetalleVenta DetalleVenta);
        List<DetalleVenta> GetDetalleVentas();
        DetalleVenta GetTDetalleVenta(int DetalleVenta);
    }
}
