using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Core.Models;
using Cars.Core.Contracts;

namespace Cars.Core.Services
{
    public class VehicleServices : IVehicleService
    {
        public readonly ICarDB _carDb;

        public VehicleServices(ICarDB carDb)
        {
            _carDb = carDb;
        }

        public async Task AddNewCar(Car car)
        {
            await _carDb.AddNewCar(car);
        }

        public async Task<List<Car>> ShowAllCars()
        {
            return await _carDb.ShowAllCars();
        }

        public async Task UpdateCar(int id, string brand, string model, int year, int numberOfDoors)
        {
            await _carDb.UpdateCar(id, brand, model, year, numberOfDoors);
        }

        public async Task DeleteCar(int id)
        {
            await _carDb.DeleteCar(id);
        }

        public async Task AddNewTruck(Truck truck)
        {
            await _carDb.AddNewTruck(truck);
        }

        public async Task<List<Truck>> ShowAllTrucks()
        {
            return await _carDb.ShowAllTrucks();
        }

        public async Task UpdateTrucks(int id, string brand, string model, int year, int cargoWeight)
        {
            await _carDb.UpdateTruck(id, brand, model, year, cargoWeight);
        }

        public async Task DeleteTruck(int id)
        {
            await _carDb.DeleteTruck(id);
        }
    }
}
