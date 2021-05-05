using CityTemperature.DTO;
using CityTemperature.DTO.AddCitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperature.Borders.UseCase
{
    public interface IAddCitysUseCase
    {
        AddCitysResponse Execute(AddCitysRequest request);
    }
}
