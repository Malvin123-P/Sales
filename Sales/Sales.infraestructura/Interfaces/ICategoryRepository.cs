using Sales.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Interfaces
{
    public interface ICategoryRepository
    {
        void Create(Category category);
        void Update(Category category);
        void Remove(Category category);
        List<Category> GetCategories();
        Category GetCategory(int id);
    }
}
