using Desafio.Core.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Desafio.Core.Entities
{
    public class DeliveryPerson : BaseEntity
    {
        public DeliveryPerson(string cnhNumber, string cnhType) : base()
        {
            CnhNumber = cnhNumber;
            CnhType = cnhType;
        }

        public DeliveryPerson(long idPerson, string cnhNumber, string cnhType) : base()
        {
            CnhNumber = cnhNumber;
            CnhType = cnhType;
            IdPerson = idPerson;
        }

        public string CnhNumber { get; private set; }
        public string CnhType { get; private set; }
        public string? CnhImageLocation { get; private set; }

        public long IdPerson { get; private set; }
        public Person Person { get; private set; }

        public List<Rent> RelatedRentals { get; private set; }

        public void SetIdPerson(long idPerson) 
        {
            IdPerson = idPerson;
        }

        public bool HasValidCnhType()
        {
            List<string> cnhValidTypes = new List<string>()
            {
                "A", "B", "A+B",
            };

            if (!cnhValidTypes.Contains(CnhType))
                return false;

            return true;
        }

        public bool HasValidCnhTypeToRent()
        {
            List<string> cnhValidTypes = new List<string>()
            {
                "A", "A+B",
            };

            if (!cnhValidTypes.Contains(CnhType))
                return false;

            return true;
        }

        public bool IsValidToCreate()
        {
            if (string.IsNullOrWhiteSpace(CnhNumber) || string.IsNullOrWhiteSpace(CnhType))
                return false;

            return true;
        }

        public void Update (string cnhImageLocation)
        {
            CnhImageLocation = cnhImageLocation;
        }

        public bool HasValidImage()
        {
            List<string> cnhValidTypes = new List<string>()
            {
                ".png", ".bmp"
            };

            if (string.IsNullOrWhiteSpace(CnhImageLocation) || !cnhValidTypes.Any(p => CnhImageLocation.EndsWith(p)))
                return false;

            return true;
        }
    }
}
