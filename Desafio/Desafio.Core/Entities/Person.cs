using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Desafio.Core.Entities
{
    public class Person : BaseEntity
    {
        public Person(string name, string cnpj, DateTime birthDate) : base()
        {
            Name = name;
            Cnpj = cnpj;
            BirthDate = birthDate;
            CreatedAt = DateTime.Now;
        }

        public string Name { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime BirthDate { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DeliveryPerson DeliveryPerson { get; private set; }

        public bool IsValidToCreate()
        {
            if (BirthDate == DateTime.MinValue || string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Cnpj))
                return false;

            return true;
        }
    }
}
