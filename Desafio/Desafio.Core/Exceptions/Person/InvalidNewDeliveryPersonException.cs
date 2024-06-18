using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Exceptions
{
    public class InvalidNewDeliveryPersonException : Exception
    {
        public InvalidNewDeliveryPersonException() : base("Check that all mandatory fields are filled in.")
        {
        }
    }
}
