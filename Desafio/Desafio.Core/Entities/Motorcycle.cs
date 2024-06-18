using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Core.Entities
{
    public class Motorcycle : BaseEntity
    {
        public Motorcycle(int year, string model, string plate) : base()
        {
            Year = year;
            Model = model;
            Plate = plate.ToUpper();

            RelatedRentals = new List<Rent>();
        }

        public int Year { get; private set; }
        public string Model { get; private set; }
        public string Plate { get; private set; }

        public List<Rent> RelatedRentals { get; private set; }

        public void Update(string plate)
        {
            Plate = plate.ToUpper();
        }

        public bool IsValidToCreate()
        {
            if (Year == int.MinValue || string.IsNullOrWhiteSpace(Model) || string.IsNullOrWhiteSpace(Plate))
                return false;

            return true;
        }

        public bool IsValidToUpdate()
        {
            if (Id == long.MinValue || string.IsNullOrWhiteSpace(Plate))
                return false;

            return true;
        }
    }
}
