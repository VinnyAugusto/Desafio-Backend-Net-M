using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Exceptions
{
    public class InvalidNewMotorcycleException : Exception
    {
        public InvalidNewMotorcycleException() : base("Check that all mandatory fields are filled in.")
        {
        }
    }
}
