using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Desafio.Core.Entities
{
    public class Rent : BaseEntity
    {
        public Rent(DateTime endDate, long idMotorcycle, long idDeliveryPerson, int rentPlan) : base()
        {
            DateTime tomorrow = DateTime.Now.AddDays(1);

            StartDate = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day);
            EndDate = endDate;
            RentPlan = rentPlan;

            IdDeliveryPerson = idDeliveryPerson;
            IdMotorcycle = idMotorcycle;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int RentPlan { get; private set; }
        public DateTime? ExpectedEndDate { get; private set; }
        public long IdMotorcycle { get; private set; }
        public Motorcycle Motorcycle { get; private set; }
        
        public long IdDeliveryPerson { get; private set; }
        public DeliveryPerson DeliveryPerson { get; private set; }

        public void UpdateExpectedEndDate(DateTime expectedEndDate) 
        {
            ExpectedEndDate = expectedEndDate;
        }

        public bool IsValidToCreate()
        {
            if (EndDate == DateTime.MinValue || IdDeliveryPerson <= 0 || IdMotorcycle <= 0 || RentPlan <= 0)
                return false;

            return true;
        }
    }
}
