using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Application.ViewModel
{
    public class MotorcycleDetailsViewModel
    {
        public MotorcycleDetailsViewModel(int year, string model, string plate, long id, DateTime createdAt)
        {
            Year = year;
            Model = model;
            Plate = plate;

            Id = id;
            CreatedAt = createdAt;
        }

        public int Year { get; private set; }
        public string Model { get; private set; }
        public string Plate { get; private set; }
        public long Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
