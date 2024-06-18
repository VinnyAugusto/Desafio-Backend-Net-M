using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Exceptions
{
    public class InvalidMotorcycleDeleteException : Exception
    {
        public InvalidMotorcycleDeleteException() : base("This motorcycle can not be deleted because it has related rentals.")
        {
        }
    }
}
