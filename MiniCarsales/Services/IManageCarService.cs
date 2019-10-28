using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniCarsales.Models;

namespace MiniCarsales.Services
{
    public interface IManageCarService
    {
        IEnumerable<Car> GetCars();
        bool DeleteCarById(int id);
        bool UpdateCar(Car car);
        bool AddNewCar(Car car);
        Car FindCarById(int id);
    }
}
