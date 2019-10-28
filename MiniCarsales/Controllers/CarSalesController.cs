using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniCarsales.Models;
using MiniCarsales.Services;

namespace MiniCarsales.Controllers
{
    [Route("api/[controller]")]
    public class CarSalesController : Controller
    {
        private readonly IManageCarService _carService;

        public CarSalesController(
            IManageCarService carService
        )
        {
            _carService = carService;
        }

        [HttpGet("GetAllCars")]
        public ActionResult<IList<Car>> GetAllCars()
        {
            var cars = _carService.GetCars();
            return Ok(cars);
        }

        [HttpPost("AddNewCar")]
        public ActionResult AddNewCar([FromBody]Car car)
        {
            var success = _carService.AddNewCar(car);
            if (success)
            {
                return Ok(car);
            }
            return BadRequest();
        }

        [HttpGet("FindCarById/{id}")]
        public ActionResult<Car> FindCarById(int id)
        {
            var car = _carService.FindCarById(id);
            if (car != null)
            {
                return Ok(car);
            }
            return NotFound();
        }

        [HttpPost("DeleteCar/{id}")]
        public ActionResult DeleteCar(int id)
        {
            var success = _carService.DeleteCarById(id);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost("UpdateCar")]
        public ActionResult UpdateCar([FromBody]Car car)
        {
            var success = _carService.UpdateCar(car);
            if (success)
            {
                return Ok(car);
            }
            return BadRequest();
        }
    }
}
