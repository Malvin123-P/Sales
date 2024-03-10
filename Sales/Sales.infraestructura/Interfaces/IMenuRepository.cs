using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregadas
using Sales.Dominio.Entities;
using Sales.Dominio.Repository;

namespace Sales.Infraestructura.Interfaces
{
    public interface IMenuRepository:IBaseRepository<Menu>
    {
       
    }
}
