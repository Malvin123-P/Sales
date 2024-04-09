using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Author;
using Sales.AplicacionCasosDEusos.Models.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AplicacionCasosDEusos.Contract.Author
{
    public interface IAuthorNewService : IBaseService<AuthorDto, AuthorDtoUpdate, AuthorRemoveDto, AuthorGetModel>
    {
        ServiceResult<AuthorGetModel> Get(int authorId);
        ServiceResult<List<AuthorGetModel>> GetAll();
    }
}
