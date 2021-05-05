using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperature.DTO
{
    public class AddCitysRequest
    {
        public string City { get; set; }
        public float Temp { get; set; }
        public float Temp_Max { get; set; }
        public float Temp_Min { get; set; }
        public DateTime DateAtualize { get; set; }
    }
}
