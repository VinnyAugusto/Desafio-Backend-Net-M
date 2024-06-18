using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Application.InputModel
{
    public class CreateDeliveryPersonInputModel
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime BirthDate { get; set; }
        public string CnhNumber { get; set; }
        public string CnhType { get; set; }

    }
}
