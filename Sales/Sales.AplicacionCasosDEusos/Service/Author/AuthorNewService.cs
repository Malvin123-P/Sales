using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contract.Author;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Author;
using Sales.AplicacionCasosDEusos.Dtos.Author;
using Sales.AplicacionCasosDEusos.Dtos.Enums;
using Sales.AplicacionCasosDEusos.Dtos.Author;
using Sales.AplicacionCasosDEusos.Models.Author;
using System;
using System.Runtime.CompilerServices;
using Sales.AplicacionCasosDEusos.Contract;
using Sales.Infraestructura.Repositories;
using Serilog.Core;
using log4net.Repository.Hierarchy;

namespace Sales.AplicacionCasosDEusos.Service.Author
{
    public class AuthorNewService : IAuthorNewService
    {
        private readonly ILogger<AuthorsRepository> logger;
        public ServiceResult<AuthorGetModel> Get(int authorId)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<List<AuthorGetModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        

        ServiceResult<AuthorGetModel> IAuthorNewService.Get(int authorId)
        {
            throw new NotImplementedException();
        }

        ServiceResult<AuthorGetModel> IBaseService<AuthorDto, AuthorsUpdateDto, AuthorsRemoveDto, AuthorGetModel>.Get(int authorId, int autorId)
        {
            throw new NotImplementedException();
        }

        ServiceResult<List<AuthorGetModel>> IAuthorNewService.GetAll()
        {
            throw new NotImplementedException();
        }

        ServiceResult<List<AuthorGetModel>> IBaseService<AuthorDto, AuthorsUpdateDto, AuthorsRemoveDto, AuthorGetModel>.GetAll()
        {
            throw new NotImplementedException();
        }

       

        ServiceResult<AuthorGetModel> IBaseService<AuthorDto, AuthorsUpdateDto, AuthorsRemoveDto, AuthorGetModel>.Remove(AuthorsRemoveDto authorsRemoveDto, AuthorsRemoveDto autorRemoveDto)
        {
            throw new NotImplementedException();
        }

        

        ServiceResult<AuthorGetModel> IBaseService<AuthorDto, AuthorsUpdateDto, AuthorsRemoveDto, AuthorGetModel>.Save(AuthorDto authorDto, AuthorDto autorDto)
        {
            throw new NotImplementedException();
        }

        ServiceResult<AuthorGetModel> IBaseService<AuthorDto, AuthorsUpdateDto, AuthorsRemoveDto, AuthorGetModel>.Update(AuthorsUpdateDto authorsUpdateDto, AuthorsUpdateDto authorUpdateDto)
        {
            throw new NotImplementedException();
        }
    }

        

       
}

public class ServiceResult<AuthorGetModel>
{
    internal Sales.AplicacionCasosDEusos.Models.Author.AuthorGetModel Data;

    public bool Success { get; internal set; }
    public string Message { get; internal set; }
}


