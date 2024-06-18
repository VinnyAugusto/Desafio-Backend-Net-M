using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Exceptions
{
    public class InvalidMotorcycleException : Exception
    {
        public InvalidMotorcycleException() : base("Motorcycle not found.")
        {
        }
    }
}
