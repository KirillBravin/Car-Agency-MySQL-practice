using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Core.Models;
using Cars.Core.Services;

namespace Cars.Core.Contracts
{
    public interface IVehicleService
    {
        Task AddNewCar(Car car);
        Task<List<Car>> ShowAllCars();
        Task UpdateCar(int id, string brand, string model, int year, int numberOfDoors);
        Task DeleteCar(int id);
        Task AddNewTruck(Truck truck);
        Task<List<Truck>> ShowAllTrucks();
        Task UpdateTrucks(int id, string brand, string model, int year, int cargoWeight);
        Task DeleteTruck(int id);
    }
}
