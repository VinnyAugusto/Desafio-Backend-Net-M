using Desafio.Application.ViewModel;
using Desafio.Application.InputModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Application.Services.Interfaces
{
    public interface IMotorcycleService
    {
        List<MotorcycleViewModel> GetAll(string plate);

        MotorcycleDetailsViewModel GetById(long id);

        long Create(CreateMotorcycleInputModel inputModel);

        void Update(UpdateMotorcycleInputModel inputModel);

        void Delete(long id);
    }
}
