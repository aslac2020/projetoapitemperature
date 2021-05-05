using CityTemperature.DTO.GetCitys;
using CityTemperature.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperature.Borders.Adapter
{
    public interface IGetCitysAdapter
    {
        public GetCitysResponse converterRequestCitysByApi(TemperatureModel city);
        public TemperatureModel converterResponseFromRequestCitys(GetCitysResponse city);
    }
}
