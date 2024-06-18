using Desafio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.InputModel
{
    public class CreateRentInputModel
    {
        public int RentPlan { get; set; }
        public long IdMotorcycle { get; set; }
        public long IdDeliveryPerson { get; set; }
    }
}
