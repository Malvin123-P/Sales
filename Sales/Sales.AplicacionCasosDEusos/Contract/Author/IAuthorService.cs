﻿using Sales.Application.Core;
using Sales.AplicacionCasosDEusos.Dtos.Author;
using Sales.AplicacionCasosDEusos.Models.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.AplicacionCasosDEusos.Contract.Author
{
    namespace Sales.Application.Contract
    {
        public interface IAuthorService : IBaseServices<AuthorDtoAdd, AuthorDtoUpdate, AuthorRemoveDto, AuthorGetModel>
        {

        }
    }
