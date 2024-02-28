using Sales.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Interfaces
{
    public interface IProductoRepository
    {
        void Create(Producto producto);
        void Update(Producto producto);
        void Remove(Producto producto);
        List<Producto> GetProductos();
        Producto GetProducto(int productId);
    }
}
