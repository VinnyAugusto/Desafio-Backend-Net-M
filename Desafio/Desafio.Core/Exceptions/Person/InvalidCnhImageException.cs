using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Exceptions
{
    public class InvalidCnhImageException : Exception
    {
        public InvalidCnhImageException() : base("Invalid Cnh Image extension. This must be '.png' or '.bmp'.")
        {
        }
    }
}
