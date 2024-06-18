using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Exceptions
{
    public class InvalidCnhTypeException : Exception
    {
        public InvalidCnhTypeException() : base("Invalid Cnh Type. This must be 'A', 'B' or 'A+B'.")
        {
        }
    }
}
