﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sales.AplicacionCasosDEusos.Exceptions
{
    public class AuthorException : Exception
    {
        public AuthorException(string Message) : base(Message)
        {

        }
    }
}