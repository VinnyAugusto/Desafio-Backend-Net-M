using Desafio.Core.Entities;
using Desafio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Application.ViewModel
{
    public class RentDetailViewModel
    {
        public RentDetailViewModel(long id, DateTime startDate, DateTime endDate, long idMotorcycle, string motorcyclePlate, string motorcycleModel, int motorcycleYear, long idDeliveryPerson, string personName, string personCnpj, string personCnh, int rentPlan)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            IdMotorcycle = idMotorcycle;
            MotorcyclePlate = motorcyclePlate;
            MotorcycleModel = motorcycleModel;
            MotorcycleYear = motorcycleYear;
            IdDeliveryPerson = idDeliveryPerson;
            PersonName = personName;
            PersonCnpj = personCnpj;
            PersonCnh = personCnh;
            RentPlan = rentPlan;
        }

        public long Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public long IdMotorcycle { get; private set; }
        public string MotorcyclePlate { get; private set; }
        public string MotorcycleModel { get; private set; }
        public int MotorcycleYear { get; private set; }
        public long IdDeliveryPerson { get; private set; }
        public string PersonName { get; private set; }
        public string PersonCnpj { get; private set; }
        public string PersonCnh { get; private set; }
        public int RentPlan { get; private set; }
    }
}
