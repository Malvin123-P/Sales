using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository where TEntity : class
    {
    }
}
