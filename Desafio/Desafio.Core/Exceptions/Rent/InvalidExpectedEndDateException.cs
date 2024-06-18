using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Exceptions
{
    public class InvalidExpectedEndDateException : Exception
    {
        public InvalidExpectedEndDateException() : base("Invalid Date.")
        {
        }
    }
}
