using CityTemperature.DTO.GetCitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperature.Borders.UseCase
{
    public interface IGetCitysUseCase
    {
       Task<GetCitysResponse> Execute(GetCitysRequest request);
    }
}
