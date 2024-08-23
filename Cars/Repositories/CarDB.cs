using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Core.Models;
using Cars.Core.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Cars.Core.Repositories
{
    public class CarDB : ICarDB
    {
        // Cars
        public async Task AddNewCar(Car car)
        {
            using (var context = new VehicleContext())
            {
                await context.Cars.AddAsync(car);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Car>> ShowAllCars()
        {
            using (var context = new VehicleContext())
            {
                List<Car> allCars = await context.Cars.ToListAsync();
                return allCars;
            }
        }

        public async Task UpdateCar(int id, string brand, string model, int year, int numberOfDoors)
        {
            using (var context = new VehicleContext())
            {
                var existingCar = await context.Cars.FindAsync(id);
                if (existingCar != null)
                {
                    existingCar.Brand = brand;
                    existingCar.Model = model;
                    existingCar.Year = year;
                    existingCar.NumberOfDoors = numberOfDoors;

                    await context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("Car not found.");
                }
            }
        }

        public async Task DeleteCar(int id)
        {
            using (var context = new VehicleContext())
            {
                context.Cars.Remove(await context.Cars.FindAsync(id));
                await context.SaveChangesAsync();
            }
        }

        // Trucks

        public async Task AddNewTruck(Truck truck)
        {
            using (var context = new VehicleContext())
            {
                await context.Trucks.AddAsync(truck);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Truck>> ShowAllTrucks()
        {
            using (var context = new VehicleContext())
            {
                List<Truck> allTrucks = await context.Trucks.ToListAsync();
                return allTrucks;
            }
        }

        public async Task UpdateTruck(int id, string brand, string model, int year, int cargoWeight)
        {
            using (var context = new VehicleContext())
            {
                var existingTruck = await context.Trucks.FindAsync(id);
                if (existingTruck != null)
                {
                    existingTruck.Brand = brand;
                    existingTruck.Model = model;
                    existingTruck.Year = year;
                    existingTruck.CargoWeight = cargoWeight;

                    await context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("Truck not found.");
                }
            }
        }

        public async Task DeleteTruck(int id)
        {
            using (var context = new VehicleContext())
            {
                context.Trucks.Remove(await context.Trucks.FindAsync(id));
                await context.SaveChangesAsync();
            }
        }
    }
}
