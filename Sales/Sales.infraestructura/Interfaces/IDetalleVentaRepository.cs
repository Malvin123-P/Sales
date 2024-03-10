using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregadas
using Sales.Dominio.Entities;
using Sales.Dominio.Repository;
using Sales.Infraestructura.Models;

namespace Sales.Infraestructura.Interfaces
{
    public interface IDetalleVentaRepository:IBaseRepository<DetalleVenta>
    {

        //Si hay relacion con otras tablas
        List<DetalleVentaModel> GetDetalleVentasByVentas(int idVentas);
        List<DetalleVentaModel> GetDetalleVentasbyProducto(int idProducto);



    }
}
