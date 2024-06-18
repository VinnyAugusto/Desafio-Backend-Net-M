using Desafio.Application.ViewModel;
using Desafio.Application.InputModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Application.Services.Interfaces
{
    public interface IDeliveryPersonService
    {
        List<DeliveryPersonViewModel> GetAll();

        DeliveryPersonDetailsViewModel GetById(long id);

        long Create(CreateDeliveryPersonInputModel inputModel);

        void Update(UpdateDeliveryPersonInputModel inputModel);

    }
}
