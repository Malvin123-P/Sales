using Editorial.Dominio.Entities;
using Sales.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Interfaces
{
    public interface INegocioRepository
    {
        void Create(Negocio Negocio);
        void Update(Negocio Negocio);
        void Remove(Negocio Negocio);
        List<Negocio> GetNegocio();
        Negocio GetNegocio(int Negocio);

    }
}
