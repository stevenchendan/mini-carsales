using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCarsales.Models;
using MiniCarsales.Repositories;

namespace MiniCarsales.Test.Repositories
{
    [TestClass]
    public class CarRepositoryTest
    {
        protected VehicleDbContext VehicleDbContext;
        protected ICarRepository CarRepository;

        [TestInitialize]
        public void InitializeCarRepositoryTest()
        {
            var options = new DbContextOptionsBuilder();
            options.UseInMemoryDatabase("Vehicle");
            VehicleDbContext = new VehicleDbContext(options.Options);
            var mockCars = new List<Car>
            {
                new Car
                {
                    BodyType = "5-door SUV",
                    EngineType = "2.0 L B20Z",
                    Make = "Honda",
                    Model = "CRV",
                    NumberOfDoors = 4,
                    NumberOfWheels = 4,
                    Year = 2018,
                    Id = 1
                },
                new Car
                {
                    BodyType = "5-door SUV",
                    EngineType = "2.0 L B20Z",
                    Make = "Honda",
                    Model = "CRV",
                    NumberOfDoors = 4,
                    NumberOfWheels = 4,
                    Year = 2019,
                    Id = 2
                }
            };
            InitializeMockDbSet(mockCars);
            CarRepository = new CarRepository(VehicleDbContext);
        }


        [TestMethod]
        public void Should_Return_Same_Amount_of_Cars_After_Call_GetCars()
        {
            //validate
            var result = CarRepository.GetCars().ToList();
            Assert.AreEqual(result.Count, 2);
        }

        [TestMethod]
        public void Should_Have_Same_Car_Id_After_Call_FindCarById()
        {

            //validate
            var result = CarRepository.FindCarById(1);
            Assert.AreEqual(result.Id, 1);
        }


        [TestMethod]
        public void Should_Return_True_After_Delete_Car()
        {

            //validate
            var car = CarRepository.FindCarById(1);
            var result = CarRepository.DeleteCar(car);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Should_Return_Same_Property_After_UpdateCar()
        {
            var car = new Car
            {
                BodyType = "5-door SUV",
                EngineType = "2.0 L B20Z",
                Make = "Honda",
                Model = "CRV",
                NumberOfDoors = 4,
                NumberOfWheels = 4,
                Year = 2021,
                Id = 2
            };

            //validate
            var result = CarRepository.UpdateCarData(car);
            var expected = CarRepository.FindCarById(car.Id);
            Assert.IsTrue(expected.Year == 2021);
        }


        [TestCleanup]
        public void Cleanup()
        {
            //For future usage
        }

        private void InitializeMockDbSet(IEnumerable<Car> mockCars)
        {
            VehicleDbContext.Cars.RemoveRange(VehicleDbContext.Cars);
            VehicleDbContext.Cars.AddRange(mockCars);
            VehicleDbContext.SaveChanges();
        }

    }
}
