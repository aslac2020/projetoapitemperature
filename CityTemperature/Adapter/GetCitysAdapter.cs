using CityTemperature.Borders.Adapter;
using CityTemperature.DTO.GetCitys;
using CityTemperature.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperature.Adapter
{
    public class GetCitysAdapter : IGetCitysAdapter
    {
        public GetCitysResponse converterRequestCitysByApi(TemperatureModel request)
        {
            var citysResponse = new GetCitysResponse();
            citysResponse.City = request.City;
            citysResponse.Temp = request.Temp;
            citysResponse.Temp_Max = request.Temp_Max;
            citysResponse.Temp_Min = request.Temp_Min;
            citysResponse.DateAtualize = request.DateAtualize;
            return citysResponse;
        }

        public TemperatureModel converterResponseFromRequestCitys(GetCitysResponse request)
        {
            var citys= new TemperatureModel();
            citys.City = request.City;
            citys.Temp = request.Temp;
            citys.Temp_Max = request.Temp_Max;
            citys.Temp_Min = request.Temp_Min;
            citys.DateAtualize = request.DateAtualize;
            return citys;
        }
    }
}
