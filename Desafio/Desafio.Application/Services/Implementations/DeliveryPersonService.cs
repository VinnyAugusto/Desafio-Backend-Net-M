using Desafio.Application.ViewModel;
using Desafio.Application.InputModel;
using System;
using System.Collections.Generic;
using System.Text;
using Desafio.Application.Services.Interfaces;
using Desafio.Infrastructure.Persistence;
using Desafio.Infrastructure.Service;
using Desafio.Core.Entities;
using Desafio.Core.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Desafio.Application.Services.Implementations
{
    public class DeliveryPersonService : IDeliveryPersonService
    {
        private readonly DesafioDbContext _dbContext;

        public DeliveryPersonService(DesafioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DeliveryPersonViewModel> GetAll()
        {
            var deliveryPeoples = _dbContext.DeliveryPerson;

            var deliveryPeopleViewModel = deliveryPeoples
                .Include(p => p.Person)
                .Select(p => new DeliveryPersonViewModel(p.Id, p.Person.Name, p.Person.Cnpj, p.Person.BirthDate, p.CnhNumber, p.CnhType))
                .ToList();

            return deliveryPeopleViewModel;
        }

        private List<Person> GetByCnpj(string cnpj)
        {
            var person = _dbContext.Person;

            var people = person
                .Where(p => (p.Cnpj.Equals(cnpj) || string.IsNullOrWhiteSpace(cnpj)))
                .ToList();

            return people;
        }

        private List<DeliveryPerson> GetByCnhNumber(string cnhNumber)
        {
            var deliveryPerson = _dbContext.DeliveryPerson;

            var deliveryPeople = deliveryPerson
                .Where(p => (p.CnhNumber.Equals(cnhNumber) || string.IsNullOrWhiteSpace(cnhNumber)))
                .ToList();

            return deliveryPeople;
        }

        public DeliveryPersonDetailsViewModel GetById(long id)
        {
            var deliveryPeople = _dbContext.DeliveryPerson
                .Include(p => p.Person)
                .SingleOrDefault(p => p.Id == id);

            if (deliveryPeople == null)
                throw new InvalidDeliveryPersonException();

            var deliveryPeopleDetailsViewModel = new DeliveryPersonDetailsViewModel(deliveryPeople.Person.Name, deliveryPeople.Person.Cnpj, deliveryPeople.Person.BirthDate, deliveryPeople.CnhNumber, deliveryPeople.CnhType, deliveryPeople.CreatedAt);

            return deliveryPeopleDetailsViewModel;
        }

        public long Create(CreateDeliveryPersonInputModel inputModel)
        {
            var people = new Person(inputModel.Name, inputModel.Cnpj, inputModel.BirthDate);

            var deliveryPeople = new DeliveryPerson(inputModel.CnhNumber, inputModel.CnhType);

            if (!people.IsValidToCreate())
                throw new InvalidNewDeliveryPersonException();

            if(!deliveryPeople.IsValidToCreate())
                throw new InvalidNewDeliveryPersonException();

            if (!deliveryPeople.HasValidCnhType())
                throw new InvalidCnhTypeException();
            
            if (GetByCnpj(inputModel.Cnpj).Any())
                throw new CnpjAlreadyRegisteredException();

            if (GetByCnhNumber(inputModel.CnhNumber).Any())
                throw new CnhAlreadyRegisteredException();

            _dbContext.Person.Add(people);
            _dbContext.SaveChanges();

            deliveryPeople.SetIdPerson(people.Id);

            _dbContext.DeliveryPerson.Add(deliveryPeople);
            _dbContext.SaveChanges();

            return deliveryPeople.Id;
        }

        public void Update(UpdateDeliveryPersonInputModel inputModel)
        {
            var deliveryPeople = _dbContext.DeliveryPerson.SingleOrDefault(p => p.Id == inputModel.Id);

            if (deliveryPeople == null)
                throw new InvalidDeliveryPersonException();

            deliveryPeople.Update(inputModel.ImageLocation);

            if (!deliveryPeople.HasValidImage())
                throw new InvalidCnhImageException();

            string filePath = inputModel.ImageLocation;
            File.WriteAllBytes(filePath, Convert.FromBase64String(inputModel.base64image));

            _dbContext.SaveChanges();
        }
    }
}
