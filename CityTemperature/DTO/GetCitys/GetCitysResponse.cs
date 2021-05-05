using CityTemperature.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperature.DTO.GetCitys
{
    public class GetCitysResponse
    {
        public string City { get; set; }
        public float Temp { get; set; }
        public float Temp_Max { get; set; }
        public float Temp_Min { get; set; }
        public DateTime DateAtualize { get; set; }
        public string msg { get; set; }
    }
}
