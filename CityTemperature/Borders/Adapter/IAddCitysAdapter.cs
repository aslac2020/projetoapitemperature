using CityTemperature.DTO;
using CityTemperature.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperature.Borders.Adapter
{
    public interface IAddCitysAdapter
    {
        public TemperatureModel converterRequestCitys(AddCitysRequest request);
    }
}
