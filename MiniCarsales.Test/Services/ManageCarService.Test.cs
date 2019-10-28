using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCarsales.Models;
using MiniCarsales.Repositories;
using MiniCarsales.Services;
using Moq;

namespace MiniCarsales.Test.Services
{
    [TestClass]
    public class ManageCarServiceTest
    {
        protected Mock<ICarRepository> CarRepository;
        protected IManageCarService CarService;

        [TestInitialize]
        public void InitializeManageCarServiceTest()
        {
            CarRepository = new Mock<ICarRepository>();
            CarService = new ManageCarService(CarRepository.Object);
        }

        [TestMethod]
        public void Shoud_Return_Same_Number_Of_Car_After_Add()
        {
            var car1 = AddCar(998);
            var car2 = AddCar(997);

            List<Car> carList = new List<Car> { car1, car2 };

            CarRepository.Setup(a => a.GetCars())
                .Returns(carList);

            var result = CarService.GetCars();
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void Should_Return_Same_Car_Id_In_FindCarById()
        {
            var car = AddCar(996);
            CarRepository.Setup(a => a.FindCarById(996))
                .Returns(car);

            //validate
            var output = CarService.FindCarById(996);
            Assert.AreEqual(output.Id, 996);
        }

        [TestMethod]
        public void Should_Return_NULL_When_Id_Not_Valid()
        {
            // mock service
            CarRepository.Setup(a => a.FindCarById(-1))
                .Returns<Car>(null);

            //validate
            var car = CarService.FindCarById(-1);
            Assert.IsNull(car);
        }

        [TestMethod]
        public void Should_Return_True_When_Add_Car()
        {
            var car = AddCar(999);
            var result = CarService.AddNewCar(car);
            Assert.IsTrue(result);
        }



        [TestMethod]
        public void Should_Return_True_When_Add_Null()
        {

            // mock service
            CarRepository.Setup(a => a.AddCar(null))
                .Returns(true);

            //validate
            var result = CarService.AddNewCar(null);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Should_Return_True_When_Delete_Exiting_Car()
        {
            //Mock Car Object with Id Property
            var car = AddCar(999);
            CarRepository.Setup(a => a.FindCarById(999)).Returns(car);
            CarRepository.Setup(a => a.DeleteCar(car)).Returns(true);
            var result = CarService.DeleteCarById(999);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Should_Return_True_When_Update_Car_Success()
        {
            Mock<Car> car = new Mock<Car>();

            // assume repository return true
            CarRepository.Setup(a => a.UpdateCarData(car.Object))
                .Returns(true);

            var result = CarService.UpdateCar(car.Object);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Should_Return_False_When_Pass_Null_To_UpdateCar()
        {
            var result = CarService.UpdateCar(null);
            Assert.IsFalse(result);
        }


        [TestCleanup]
        public void Cleanup()
        {
            //rollback transaction
        }


        private Car AddCar(int id)
        {
            Mock<Car> car = new Mock<Car>();
            car.Object.Id = id;

            CarRepository.Setup(a => a.AddCar(car.Object))
                .Returns(true);
            return car.Object;
        }
    }
}
