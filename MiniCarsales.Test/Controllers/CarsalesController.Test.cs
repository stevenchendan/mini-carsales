using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCarsales.Controllers;
using MiniCarsales.Models;
using MiniCarsales.Services;
using Moq;

namespace MiniCarsales.Test.Controllers
{
    [TestClass]
    public class CarSalesControllerTest
    {
        protected Mock<IManageCarService> CarService;
        protected CarSalesController Controller;

        [TestInitialize]
        public void InitializeCarSalesControllerTest()
        {
            CarService = new Mock<IManageCarService>();
            Controller = new CarSalesController(
                CarService.Object
                );
        }

        [TestMethod]
        public void Should_Return_OkObjectResult_After_Call_GetAllCars()
        {
            //mock data
            var mockCars = new List<Car>()
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
                },
                new Car
                {
                    BodyType = "5-door SUV",
                    EngineType = "2.0 L B20Z",
                    Make = "Honda",
                    Model = "CRV",
                    NumberOfDoors = 4,
                    NumberOfWheels = 4,
                    Year = 2020,
                    Id = 3
                }
            };

            CarService.Setup(a => a.GetCars()).Returns(mockCars);

            var result = (OkObjectResult)Controller.GetAllCars().Result;
            Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.OK);
        }

        [TestMethod]
        public void Should_Reture_OkResult_After_Call_FindCarById()
        {
            Mock<Car> car = new Mock<Car>();
            car.Object.Id = 999;
            CarService.Setup(a => a.FindCarById(999)).Returns(car.Object);

            var result = (OkObjectResult)Controller.FindCarById(999).Result;
            Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.OK);
        }


        [TestMethod]
        public void Should_Return_OkResultAfter_AddNewCar()
        {
            Mock<Car> car = new Mock<Car>();

            CarService.Setup(a => a.AddNewCar(car.Object)).Returns(true);

            var result = (OkObjectResult)Controller.AddNewCar(car.Object);
            Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.OK);
        }



        [TestMethod]
        public void Should_Return_OkResult_After_Call_DeleteCar()
        {

            CarService.Setup(a => a.DeleteCarById(1)).Returns(true);

            var result = (OkResult)Controller.DeleteCar(1);
            Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.OK);
        }


        [TestMethod]
        public void Should_Return_OkResult_After_Call_UpdateCar()
        {
            //mock data
            var mockCar = new Car()
            {
                BodyType = "5-door SUV",
                EngineType = "2.0 L B20Z",
                Make = "Honda",
                Model = "CRV",
                NumberOfDoors = 4,
                NumberOfWheels = 4,
                Year = 2020,
                Id = 1
            };

            CarService.Setup(a => a.UpdateCar(mockCar)).Returns(true);

            var result = (OkObjectResult)Controller.UpdateCar(mockCar);
            Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.OK);
        }


        [TestCleanup]
        public void Cleanup()
        {
            //For future usage
        }
    }
}
