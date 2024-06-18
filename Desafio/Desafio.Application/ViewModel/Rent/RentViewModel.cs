using Desafio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Application.ViewModel
{
    public class RentViewModel
    {
        public RentViewModel(long id, DateTime startDate, DateTime endDate, long idMotorcycle, string motorcyclePlate, long idDeliveryPerson, string peopleName, int rentPlan)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            IdMotorcycle = idMotorcycle;
            MotorcyclePlate = motorcyclePlate;
            IdDeliveryPerson = idDeliveryPerson;
            PeopleName = peopleName;
        }

        public long Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public long IdMotorcycle { get; private set; }
        public string MotorcyclePlate { get; private set; }
        public long IdDeliveryPerson { get; private set; }
        public string PeopleName { get; private set; }
        public int rentPlan { get; private set; }
    }
}
