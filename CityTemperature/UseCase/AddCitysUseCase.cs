using CityTemperature.Borders.Adapter;
using CityTemperature.Borders.Interfaces;
using CityTemperature.Borders.UseCase;
using CityTemperature.DTO;
using CityTemperature.DTO.AddCitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperature.UseCase
{
    public class AddCitysUseCase : IAddCitysUseCase
    {
        private readonly ITemperatureRepositories _repositoriesCity;
        private readonly IAddCitysAdapter _addCityAdapter;

        public AddCitysUseCase(ITemperatureRepositories temperatureRepositories, IAddCitysAdapter addCitysAdapter )
        {
            _repositoriesCity = temperatureRepositories;
            _addCityAdapter = addCitysAdapter;
        }

        public AddCitysResponse Execute(AddCitysRequest request)
        {
            var response = new AddCitysResponse();

            try
            {
                if ( request.City.Length < 3)
                {
                    response.msg = "Erro ao adicionar a cidade";
                    return response;
                }

                var addCity = _addCityAdapter.converterRequestCitys(request);
                _repositoriesCity.Add(addCity);
                response.msg = "Cidade Adicionada com sucesso";
                response.id = addCity.Id;
                return response;

            }
            catch (Exception)
            {
                response.msg = "Erro ao adicionar a cidade";
                return response;
            }

        }
    }
}
