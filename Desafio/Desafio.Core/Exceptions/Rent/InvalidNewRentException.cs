using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Exceptions
{
    public class InvalidNewRentException : Exception
    {
        public InvalidNewRentException() : base("Check that all mandatory fields are filled in.")
        {
        }
    }
}
