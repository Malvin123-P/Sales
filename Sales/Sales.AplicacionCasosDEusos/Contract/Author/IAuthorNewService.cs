using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Author;
using Sales.AplicacionCasosDEusos.Models.Author;
using Sales.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AplicacionCasosDEusos.Contract.Author
{
    public interface IAuthorNewService : IBaseServices<AuthorDtoUpdate, AuthorDtoUpdate, AuthorRemoveDto, AuthorGetModel>
    {
        ServicesResult<AuthorGetModel> Get(int authorId);
        ServicesResult<List<AuthorGetModel>> GetAll();

        ServicesResult<AuthorGetModel> GetAuthor();

        ServicesResult<List<AuthorGetModel>> Save(AuthorDtoAdd authorsAddModel);
    }
}
