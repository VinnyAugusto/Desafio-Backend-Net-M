using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Application.ViewModel
{
    public class DeliveryPersonViewModel
    {
        public DeliveryPersonViewModel(long id, string name, string cnpj, DateTime birthDate, string cnhNumber, string cnhType)
        {
            Id = id;
            Name = name;
            Cnpj = cnpj;
            BirthDate = birthDate;
            CnhNumber = cnhNumber;
            CnhType = cnhType;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string CnhNumber { get; private set; }
        public string CnhType { get; private set; }
    }
}
