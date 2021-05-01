using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperature.Models
{
    public class TemperatureModel
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public float Temp { get; set; }
        public float Temp_Max { get; set; }
        public float Temp_Min { get; set; }
        public DateTime DateAtualize { get; set; }
    }

}

