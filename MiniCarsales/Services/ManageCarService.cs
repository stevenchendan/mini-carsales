using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniCarsales.Models;
using MiniCarsales.Repositories;

namespace MiniCarsales.Services
{
    public class ManageCarService : IManageCarService
    {
        private readonly ICarRepository _carRepository;

        public ManageCarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public IEnumerable<Car> GetCars()
        {
            var cars = _carRepository.GetCars();
            return cars;
        }

        public Car FindCarById(int id)
        {
            var car = _carRepository.FindCarById(id);
            return car;
        }

        public bool AddNewCar(Car car)
        {
            bool addCarSuccess = _carRepository.AddCar(car);
            return addCarSuccess;
        }

        public bool DeleteCarById(int id)
        {
            var car = _carRepository.FindCarById(id);
            if (car == null)
            {
                return false;
            }
            bool deleteCarSuccess = _carRepository.DeleteCar(car);
            return deleteCarSuccess;
        }

        public bool UpdateCar(Car car)
        {
            bool updateCarSuccess = _carRepository.UpdateCarData(car);
            return updateCarSuccess;
        }
    }
}
