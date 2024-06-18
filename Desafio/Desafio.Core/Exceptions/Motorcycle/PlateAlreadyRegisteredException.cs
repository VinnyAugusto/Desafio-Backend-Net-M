using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Exceptions
{
    public class PlateAlreadyRegisteredException : Exception
    {
        public PlateAlreadyRegisteredException() : base("This Plate is already registered.")
        {
        }
    }
}
