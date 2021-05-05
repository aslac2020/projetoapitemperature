using CityTemperature.Borders.Adapter;
using CityTemperature.DTO;
using CityTemperature.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperature.Adapter
{
    public class AddCitysAdapter : IAddCitysAdapter
    {
        public TemperatureModel converterRequestCitys(AddCitysRequest request)
        {
            var citysTemperature = new TemperatureModel();
            citysTemperature.City = request.City;
            citysTemperature.Temp = request.Temp;
            citysTemperature.Temp_Max = request.Temp_Max;
            citysTemperature.Temp_Min = request.Temp_Min;
            citysTemperature.DateAtualize = request.DateAtualize;

            return citysTemperature;
        }
    }
}
