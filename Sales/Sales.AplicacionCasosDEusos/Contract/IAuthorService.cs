using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Author;
using Sales.AplicacionCasosDEusos.Models.Author;

namespace Sales.AplicacionCasosDEusos.Contract
{
    public interface IAuthorService
    {
        ServiceResult<List<AuthorGetModel>> GetAuthors();
        ServiceResult<AuthorGetModel> GetAuthor(int authorId);
        ServiceResult<AuthorGetModel> SaveAuthor(AuthorDto authorDto);

        ServiceResult<AuthorGetModel> UpdateRol(AuthorsUpdateDto authorsUpdateDto);

        ServiceResult<AuthorGetModel> RemoveRol(AuthorsRemoveDto authorsRemoveDto);
    }
}
