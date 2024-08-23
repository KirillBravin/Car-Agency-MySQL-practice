using Cars.Core.Models;
using Cars.Core.Services;
using Cars.Core.Repositories;
using Cars.Core.Contracts;
using System;
using System.Threading.Channels;
using Microsoft.Identity.Client;
using System.Runtime.ConstrainedExecution;

namespace CarAgency
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ICarDB carDb = new CarDB();
            IVehicleService _vehicleService = new VehicleServices(carDb);

            while (true)
            {
                Console.WriteLine("1. Add new car.");
                Console.WriteLine("2. Add new truck.");
                Console.WriteLine("3. Show all cars.");
                Console.WriteLine("4. Show all trucks.");
                Console.WriteLine("5. Modify car.");
                Console.WriteLine("6. Modify truck.");
                Console.WriteLine("7. Delete car.");
                Console.WriteLine("8. Delete truck.");
                Console.WriteLine("0. Exit.");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            Console.WriteLine("Brand: ");
                            string newCarBrand = Console.ReadLine();
                            Console.WriteLine("Model: ");
                            string newCarModel = Console.ReadLine();
                            Console.WriteLine("Year: ");
                            int newCarYear = int.Parse(Console.ReadLine());
                            Console.WriteLine("Number of doors: ");
                            int newCarDoorAmount = int.Parse(Console.ReadLine());

                            Car newCar = new Car
                            {
                                Brand = newCarBrand,
                                Model = newCarModel,
                                Year = newCarYear,
                                NumberOfDoors = newCarDoorAmount
                            };

                            await _vehicleService.AddNewCar(newCar);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Brand: ");
                            string newTruckBrand = Console.ReadLine();
                            Console.WriteLine("Model: ");
                            string newTruckModel = Console.ReadLine();
                            Console.WriteLine("Year: ");
                            int newTruckYear = int.Parse(Console.ReadLine());
                            Console.WriteLine("Cargo weight: ");
                            int cargoWeight = int.Parse(Console.ReadLine());

                            Truck newTruck = new Truck
                            {
                                Brand = newTruckBrand,
                                Model = newTruckModel,
                                Year = newTruckYear,
                                CargoWeight = cargoWeight
                            };

                            await _vehicleService.AddNewTruck(newTruck);
                            break;
                        }
                    case "3":
                        {
                            var cars = await _vehicleService.ShowAllCars();

                            if (cars.Count == 0)
                            {
                                Console.WriteLine("No cars available");
                            }
                            else
                            {
                                foreach(var car in cars)
                                {
                                    Console.WriteLine($"ID: {car.Id}, Brand: {car.Brand}, Model: {car.Model}, Year: {car.Year}, Number of doors: {car.NumberOfDoors}");
                                }
                            }
                            break;
                        }
                    case "4":
                        {
                            var trucks = await _vehicleService.ShowAllTrucks();

                            if (trucks.Count == 0)
                            {
                                Console.WriteLine("No trucks available.");
                            }
                            else
                            {
                                foreach(var truck in trucks)
                                {
                                    Console.WriteLine($"ID: {truck.Id}, Brand: {truck.Brand}, Model: {truck.Model}, Year: {truck.Year}, Cargo weight: {truck.CargoWeight}");
                                }
                            }
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Enter id of the car to be updated: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new brand: ");
                            string newBrand = Console.ReadLine();
                            Console.WriteLine("Enter new model: ");
                            string newModel = Console.ReadLine();
                            Console.WriteLine("Enter new year");
                            int newYear = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter number of doors: ");
                            int numOfDoors = int.Parse(Console.ReadLine());

                            await _vehicleService.UpdateCar(id, newBrand, newModel, newYear, numOfDoors);

                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("Enter id of the truck to be updated: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new brand: ");
                            string newBrand = Console.ReadLine();
                            Console.WriteLine("Enter new model: ");
                            string newModel = Console.ReadLine();
                            Console.WriteLine("Enter new year");
                            int newYear = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter number of doors: ");
                            int cargoWeight = int.Parse(Console.ReadLine());

                            await _vehicleService.UpdateTrucks(id, newBrand, newModel, newYear, cargoWeight);

                            break;
                        }
                    case "7":
                        {
                            Console.WriteLine("Enter id of car to be deleted: ");
                            int id = int.Parse(Console.ReadLine());
                            await _vehicleService.DeleteCar(id);
                            break;
                        }
                    case "8":
                        {
                            Console.WriteLine("Enter id of truck to be deleted: ");
                            int id = int.Parse(Console.ReadLine());
                            await _vehicleService.DeleteTruck(id);
                            break;
                        }
                    case "0":
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }
    }
}