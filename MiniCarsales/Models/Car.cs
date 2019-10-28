using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Models
{
    public class Car : Vehicle
    {
        public string EngineType { get; set; }
        [Required]
        public string BodyType { get; set; }
        [Required]
        public int NumberOfWheels { get; set; }
        [Required]
        public int NumberOfDoors { get; set; }

        public Car()
        {
            VehicleType = VehicleType.Car; ;
        }
    }
}
