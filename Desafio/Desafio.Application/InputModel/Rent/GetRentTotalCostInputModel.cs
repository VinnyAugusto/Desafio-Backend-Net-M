using Desafio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.InputModel
{
    public class GetRentTotalCostInputModel
    {
        public long Id { get; set; }
        public DateTime ExpectedEndDate { get; set; }
    }
}