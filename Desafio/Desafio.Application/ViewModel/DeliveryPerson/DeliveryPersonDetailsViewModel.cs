using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Application.ViewModel
{
    public class DeliveryPersonDetailsViewModel
    {
        public DeliveryPersonDetailsViewModel(string name, string cnpj, DateTime birthDate, string cnhNumber, string cnhType, DateTime createdAt)
        {
            Name = name;
            Cnpj = cnpj;
            BirthDate = birthDate;
            CnhNumber = cnhNumber;
            CnhType = cnhType;
            CreatedAt = createdAt;
        }
        
        public string Name { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string CnhNumber { get; private set; }
        public string CnhType { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
