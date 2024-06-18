using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Exceptions
{
    public class CnpjAlreadyRegisteredException : Exception
    {
        public CnpjAlreadyRegisteredException() : base("This Cnpj is already registered.")
        {
        }
    }
}
