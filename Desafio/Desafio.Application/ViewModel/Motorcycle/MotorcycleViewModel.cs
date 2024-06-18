using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Application.ViewModel
{
    public class MotorcycleViewModel
    {
        public MotorcycleViewModel(long id, int year, string model, string plate)
        {
            Id = id;
            Year = year;
            Model = model;
            Plate = plate;
        }

        public long Id { get; private set; }
        public int Year { get; private set; }
        public string Model { get; private set; }
        public string Plate { get; private set; }
    }
}
