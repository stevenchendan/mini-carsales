using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using MiniCarsales.Models;

namespace MiniCarsales.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars();
        Car FindCarById(int id);
        bool AddCar(Car car);
        bool DeleteCar(Car car);
        bool UpdateCarData(Car car);
    }

    public class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly VehicleDbContext _context;

        public CarRepository(VehicleDbContext context) : base(context)
        {
            _context = context;
            if (EnumerableExtensions.Any(_context.Cars)) return;
            _context.Cars.AddRangeAsync(new List<Car>
            {
                new Car
                {
                    BodyType = "5-door SUV",
                    EngineType = "2.0 L B20Z",
                    Make = "Honda",
                    Model = "CRV",
                    NumberOfDoors = 4,
                    NumberOfWheels = 4,
                    Year = 2018
                }
            });
            _context.SaveChanges();
        }

        public IEnumerable<Car> GetCars()
        {
            return _context.Cars;
        }


        public Car FindCarById(int id)
        {
            return _context.Cars.SingleOrDefault(c => c.Id == id);
        }

        public bool AddCar(Car car)
        {
            try
            {
                _context.Cars.Add(car);
                return _context.SaveChanges() == 1;
            }
            catch (Exception exception)
            {
                return false;
            }

        }

        public bool DeleteCar(Car car)
        {
            try
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public bool UpdateCarData(Car car)
        {

            var exitingCar = _context.Cars.SingleOrDefault(c => c.Id == car.Id);
            if (exitingCar == null)
            {
                return false;
            }

            exitingCar.BodyType = car.BodyType;
            exitingCar.EngineType = car.EngineType;
            exitingCar.NumberOfDoors = car.NumberOfDoors;
            exitingCar.NumberOfWheels = car.NumberOfWheels;
            exitingCar.Make = car.Make;
            exitingCar.Model = car.Model;
            exitingCar.Year = car.Year;
            _context.SaveChanges();
            return true;
        }
    }
}
