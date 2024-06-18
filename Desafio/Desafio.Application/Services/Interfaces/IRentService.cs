using Desafio.Application.ViewModel;
using Desafio.Application.InputModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Application.Services.Interfaces
{
    public interface IRentService
    {
        List<RentViewModel> GetAll();

        RentDetailViewModel GetById(long id);

        long Create(CreateRentInputModel inputModel);

        RentTotalCostViewModel GetTotalCost(GetRentTotalCostInputModel inputModel);

    }
}
