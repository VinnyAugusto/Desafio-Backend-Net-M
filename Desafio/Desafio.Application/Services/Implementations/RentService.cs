using Desafio.Application.InputModel;
using Desafio.Application.Services.Interfaces;
using Desafio.Application.ViewModel;
using Desafio.Core.Entities;
using Desafio.Core.Enums;
using Desafio.Core.Exceptions;
using Desafio.Core.Util;
using Desafio.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.Services.Implementations
{
    public class RentService : IRentService
    {
        private readonly DesafioDbContext _dbContext;

        public RentService(DesafioDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<RentViewModel> GetAll()
        {
            var rentals = _dbContext.Rent;

            var deliveryPeopleViewModel = rentals
                .Include(p => p.DeliveryPerson)
                .Include(p => p.Motorcycle)
                .Include(p => p.DeliveryPerson.Person)
                .Select(p => new RentViewModel(p.Id, p.StartDate, p.EndDate, p.IdMotorcycle, p.Motorcycle.Plate, p.IdDeliveryPerson, p.DeliveryPerson.Person.Name, p.RentPlan))
                .ToList();

            return deliveryPeopleViewModel;
        }

        public RentDetailViewModel GetById(long id)
        {
            var rent = _dbContext.Rent
                .Include(p => p.DeliveryPerson)
                .Include(p => p.Motorcycle)
                .Include(p => p.DeliveryPerson.Person)
                .SingleOrDefault(p => p.Id == id);

            if (rent == null)
                throw new InvalidRentException();

            var rentDetailsViewModel = new RentDetailViewModel(rent.Id, rent.StartDate, rent.EndDate, rent.IdMotorcycle, rent.Motorcycle.Plate, rent.Motorcycle.Model, rent.Motorcycle.Year, rent.IdDeliveryPerson, rent.DeliveryPerson.Person.Name, rent.DeliveryPerson.Person.Cnpj, rent.DeliveryPerson.CnhNumber, rent.RentPlan);

            return rentDetailsViewModel;
        }

        public long Create(CreateRentInputModel inputModel)
        {
            DateTime endDate = DateTime.Now.AddDays(1).AddDays(GetPlanDays(inputModel.RentPlan));

            var rent = new Rent(endDate, inputModel.IdMotorcycle, inputModel.IdDeliveryPerson, inputModel.RentPlan);

            if (!rent.IsValidToCreate())
                throw new InvalidNewRentException();

            var deliveryPeople = _dbContext.DeliveryPerson
                .SingleOrDefault(p => p.Id == inputModel.IdDeliveryPerson);

            if (deliveryPeople == null)
                throw new InvalidDeliveryPersonException();

            if (!deliveryPeople.HasValidCnhTypeToRent())
                throw new InvalidCnhTypeToRentException();

            _dbContext.Rent.Add(rent);
            _dbContext.SaveChanges();

            return rent.Id;
        }

        public RentTotalCostViewModel GetTotalCost(GetRentTotalCostInputModel inputModel)
        {
            var rent = _dbContext.Rent
                .Include(p => p.DeliveryPerson)
                .Include(p => p.Motorcycle)
                .Include(p => p.DeliveryPerson.Person)
                .SingleOrDefault(p => p.Id == inputModel.Id);

            if (rent == null)
                throw new InvalidRentException();

            if ((DatetimeUtil.getDate(inputModel.ExpectedEndDate) - DatetimeUtil.getDate(rent.StartDate)).Days < 0)
                throw new InvalidExpectedEndDateException();

            rent.UpdateExpectedEndDate(inputModel.ExpectedEndDate);

            _dbContext.SaveChanges();

            var rentTotalCostViewModel = new RentTotalCostViewModel(rent.Id, rent.StartDate, rent.ExpectedEndDate.Value, rent.RentPlan);

            decimal totalCost = CalculateTotalCost(rent);

            rentTotalCostViewModel.SetTotalCost(totalCost);

            return rentTotalCostViewModel;
        }

        private decimal CalculateTotalCost(Rent rent)
        {
            var AmmountDays = (DatetimeUtil.getDate(rent.ExpectedEndDate.Value) - DatetimeUtil.getDate(rent.StartDate)).Days;

            decimal RentPlanDailyCost = 0m;
            int RentPlanDays = 0;
            decimal RentAdditionalTax = 0m;

            switch ((RentPlanEnum)rent.RentPlan) 
            {
                case RentPlanEnum.Plano7Dias:
                    RentPlanDailyCost = 30m; RentPlanDays = 7; RentAdditionalTax = 20m;
                    break;
                case RentPlanEnum.Plano15Dias:
                    RentPlanDailyCost = 28m; RentPlanDays = 15; RentAdditionalTax = 40m;
                    break;
                case RentPlanEnum.Plano30Dias:
                    RentPlanDailyCost = 22m; RentPlanDays = 30;
                    break;
                case RentPlanEnum.Plano45Dias:
                    RentPlanDailyCost = 20m; RentPlanDays = 45;
                    break;
                case RentPlanEnum.Plano50Dias:
                    RentPlanDailyCost = 18m; RentPlanDays = 50;
                    break;
                default:
                    break;
            }

            if(AmmountDays == RentPlanDays)
            {
                return RentPlanDailyCost * (decimal)RentPlanDays;
            }
            
            if (AmmountDays > RentPlanDays)
            {
                return ((RentPlanDailyCost * (decimal)RentPlanDays) + ((AmmountDays - RentPlanDays) * 50));
            }

            //(AmmountDays < RentPlanDays)
            decimal additionalTax = (((RentPlanDays - AmmountDays) * RentPlanDailyCost) * (RentAdditionalTax / 100m));
            return ((RentPlanDailyCost * (decimal)AmmountDays) + additionalTax);
        }

        private int GetPlanDays(int rentPlan)
        {
            switch ((RentPlanEnum)rentPlan)
            {
                case RentPlanEnum.Plano7Dias:
                    return 7;
                    break;
                case RentPlanEnum.Plano15Dias:
                    return 15;
                    break;
                case RentPlanEnum.Plano30Dias:
                    return 30;
                    break;
                case RentPlanEnum.Plano45Dias:
                    return 45;
                    break;
                case RentPlanEnum.Plano50Dias:
                    return 50;
                    break;
                default:
                    return 0;
                    break;
            }
        }
    }
}
