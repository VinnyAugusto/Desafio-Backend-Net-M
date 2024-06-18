using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Exceptions
{
    public class CnhAlreadyRegisteredException : Exception
    {
        public CnhAlreadyRegisteredException() : base("This Cnh is already registered.")
        {
        }
    }
}
