using CityTemperature.DTO.GetCitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperature.Borders.Adapter
{
    public interface ISearchCityApiAdapter
    {
        Task<GetCitysResponse> GetTemperatureCityApi(string request);
    }
}
