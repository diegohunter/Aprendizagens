using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coad.GenericCrud.Exceptions
{
    /// <summary>
    /// Exception Para indicar erro de permissão de acesso ou de login
    /// </summary>
    public class DbEntityValidationException : ValidacaoException
    {
        private string message;

        public DbEntityValidationException()
        {

        }

        public DbEntityValidationException(string message) : base(message)
        {
            
        }

        public DbEntityValidationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

    }
}