using Desafio.Application.ViewModel;
using Desafio.Application.InputModel;
using System;
using System.Collections.Generic;
using System.Text;
using Desafio.Application.Services.Interfaces;
using Desafio.Infrastructure.Persistence;
using Desafio.Core.Entities;
using Desafio.Core.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Application.Services.Implementations
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly DesafioDbContext _dbContext;

        public MotorcycleService(DesafioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<MotorcycleViewModel> GetAll(string plate)
        {
            var motorcycles = _dbContext.Motorcycle;

            var motorcycleViewModel = motorcycles
                .Where(p => string.IsNullOrWhiteSpace(plate) || p.Plate.Equals(plate))
                .Select(p => new MotorcycleViewModel(p.Id, p.Year, p.Model, p.Plate))
                .ToList();

            return motorcycleViewModel;
        }

        public MotorcycleDetailsViewModel GetById(long id)
        {
            var motorcycle = _dbContext.Motorcycle
                .Include(p => p.RelatedRentals)
                .SingleOrDefault(p => p.Id == id);

            if (motorcycle == null)
                throw new InvalidMotorcycleException();

            var motorcycleViewModel = new MotorcycleDetailsViewModel(motorcycle.Year, motorcycle.Model, motorcycle.Plate, motorcycle.Id, motorcycle.CreatedAt);

            return motorcycleViewModel;
        }

        public long Create(CreateMotorcycleInputModel inputModel)
        {
            var motorcycle = new Motorcycle(inputModel.Year, inputModel.Model, inputModel.Plate);

            if (!motorcycle.IsValidToCreate())
                throw new InvalidNewMotorcycleException();

            if (GetAll(motorcycle.Plate).Any())
                throw new PlateAlreadyRegisteredException();

            _dbContext.Motorcycle.Add(motorcycle);
            _dbContext.SaveChanges();

            //TODO: Lançar mensageria

            return motorcycle.Id;
        }

        public void Update(UpdateMotorcycleInputModel inputModel)
        {
            var motorcycle = _dbContext.Motorcycle.SingleOrDefault(p => p.Id == inputModel.Id);

            if (motorcycle == null)
                throw new InvalidMotorcycleException();

            motorcycle.Update(inputModel.Plate);

            if (GetAll(motorcycle.Plate).Any(p => p.Id != inputModel.Id))
                throw new PlateAlreadyRegisteredException();

            if(!motorcycle.IsValidToUpdate())
                throw new InvalidMotorcycleException();

            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var motorcycle = _dbContext.Motorcycle
                .Include(p => p.RelatedRentals)
                .SingleOrDefault(p => p.Id == id);

            if (motorcycle == null)
                throw new InvalidMotorcycleException();

            if(motorcycle.RelatedRentals.Any())
                throw new InvalidMotorcycleDeleteException();

            _dbContext.Entry(motorcycle).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }
    }
}
