using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Exceptions
{
    public class InvalidRentException : Exception
    {
        public InvalidRentException() : base("Rent not found.")
        {
        }
    }
}
