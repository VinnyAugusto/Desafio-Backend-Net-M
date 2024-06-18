using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Exceptions
{
    public class InvalidCnhTypeToRentException : Exception
    {
        public InvalidCnhTypeToRentException() : base("Invalid Cnh Type to Rent. The delivery person must have cnh type 'A' or 'A+B'.")
        {
        }
    }
}
