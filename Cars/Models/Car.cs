using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.Models
{
    public class Car : Vehicle
    {
        public int Id { get; set; }
        public int NumberOfDoors { get; set; }

        public Car (string brand, string model, int year, int numberOfDoors) : base (brand, model, year)
        {
            Brand = brand;
            Model = model;
            Year = year;
            NumberOfDoors = numberOfDoors;
        }

        public Car() { }
    }
}
