using Editorial.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Interfaces
{
    public interface IMenuRepository
    {
        void Create(Menu Menu);
        void Update(Menu Menu);
        void Remove(Menu Menu);
        List<Menu> GetMenus();
        Menu GetMenu(int Menu);
    }
}
