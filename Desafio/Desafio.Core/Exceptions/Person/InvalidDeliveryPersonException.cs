using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Exceptions
{
    public class InvalidDeliveryPersonException : Exception
    {
        public InvalidDeliveryPersonException() : base("Delivery Person not found.")
        {
        }
    }
}
