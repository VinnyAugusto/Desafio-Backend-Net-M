using Desafio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Application.ViewModel
{
    public class RentTotalCostViewModel
    {
        public RentTotalCostViewModel(long id, DateTime startDate, DateTime expectedEndDate, int rentPlan)
        {
            Id = id;
            StartDate = startDate;
            ExpectadeEndDate = expectedEndDate;
            RentPlan = rentPlan;
        }

        public long Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime ExpectadeEndDate { get; private set; }
        public decimal TotalCost { get; private set; }
        public int RentPlan { get; private set; }

        public void SetTotalCost(decimal totalCost)
        {
            TotalCost = totalCost; 
        }    

    }
}
