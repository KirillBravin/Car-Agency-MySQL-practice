using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.Models
{
    public class Truck : Vehicle
    {
        public int Id { get; set; }
        public int CargoWeight { get; set; }

        public Truck() { }

        public Truck(string brand, string model, int year, int cargoWeight) : base (brand, model, year)
        {
            Brand = brand;
            Model = model;
            Year = year;
            CargoWeight = cargoWeight;
        }
    }
}
