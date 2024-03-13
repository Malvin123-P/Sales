using Sales.Dominio.Entities;
using Sales.Dominio.Repository;
using Sales.Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Interfaces
{
    public interface IProductoRepository : IBaseRepository<Producto>
    {
        List<ProductoModel> GetProductsByCategory(int categoryId);

    }
}
