using CityTemperature.Borders.Adapter;
using CityTemperature.Borders.Interfaces;
using CityTemperature.Borders.UseCase;
using CityTemperature.DTO.GetCitys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace CityTemperature.UseCase
{
    public class GetCitysUseCase : IGetCitysUseCase
    {

        private readonly ITemperatureRepositories _repositoriesCity;
        private readonly IGetCitysAdapter _getCitysAdapter;
        private readonly ISearchCityApiAdapter _searchCityApiAdapter;
        private string _cityRequestToUpper;
        private string _cityNameToUpper;

        public GetCitysUseCase(ITemperatureRepositories repositories, 
            IGetCitysAdapter adapterGet, ISearchCityApiAdapter apiAdapter)
        {
            _repositoriesCity = repositories;
            _getCitysAdapter = adapterGet;
            _searchCityApiAdapter = apiAdapter;
        }

        public async Task<GetCitysResponse> Execute(GetCitysRequest city)
        {
            var response = new GetCitysResponse();
            _cityRequestToUpper = city.city.ToUpper();

            try
            {
                var cityName = _repositoriesCity.GetCity(city.city);
                _cityNameToUpper = cityName.City.ToUpper();

                if (cityName == null)
                {
                    var citySearch = await _searchCityApiAdapter.GetTemperatureCityApi(city.city);

                    if (citySearch == null)
                    {
                        response.msg = "Cidade não encontrada :(";
                        return response;
                    }

                    var cityNew = _getCitysAdapter.converterResponseFromRequestCitys(citySearch);
                     _repositoriesCity.Add(cityNew);
                    response.msg = "Cidade encontrada com sucesso";
                    return response;
                }

                if (_cityRequestToUpper == _cityNameToUpper)
                {
                    var dateNow = DateTime.Now;
                    var dateMysql = cityName.DateAtualize;

                    var resultMinutes = GetMinutesInterval(dateNow, dateMysql);

                    if (resultMinutes == false)
                    {
                        response = _getCitysAdapter.converterRequestCitysByApi(cityName);
                        response.msg = "Cidade encontrada :)";
                        return response;
                    }
                    else
                    {
                        var searchCityApi = await _searchCityApiAdapter.GetTemperatureCityApi(city.city);
                        var newCidade = _getCitysAdapter.converterResponseFromRequestCitys(searchCityApi);
                        _repositoriesCity.Update(newCidade, cityName.Id);
                        searchCityApi.msg = "Cidade encontrada :)";
                        return searchCityApi;
                    }

                }

                response = _getCitysAdapter.converterRequestCitysByApi(cityName);
                return response;

            }
            catch (Exception)
            {

                response.msg = "Falha ao encontrar a cidade :(";
                return response;
            }

        }

        public Boolean GetMinutesInterval(DateTime dateNow, DateTime dateMysql)
        {
            var compare = dateNow - dateMysql;
            var compareMinutes = (int)compare.TotalMinutes;

            if (compareMinutes <= 20)
            {
                return false;
            }

            return true;
        }
    }
}
