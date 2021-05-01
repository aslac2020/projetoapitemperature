using CityTemperature.Context;
using CityTemperature.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static CityTemperature.Models.CityModels;

namespace CityTemperature.Repositories
{
    public class TemperatureRepositories : ITemperatureRepositories
    {
        private readonly TemperatureContext _temperaturecontext;
        public TemperatureRepositories(TemperatureContext context)
        {
            _temperaturecontext = context;
        }

        public async Task<TemperatureModel> Add(string city)
        {
            var response = new TemperatureModel();

            var getCity = _temperaturecontext.TemperatureCitys.Where(x => x.City == city).FirstOrDefault();

            if (getCity == null)
            {
                var searchCityApi = await GetCitySearchByApi(city);

                if (searchCityApi == null)
                {
                    return null;
                }

                _temperaturecontext.TemperatureCitys.Add(searchCityApi);
                _temperaturecontext.SaveChanges();

                return searchCityApi;
            }

            if (getCity.City.ToUpper() == city.ToUpper())
            {
                var dateNow = DateTime.Now;
                var dateMysql = getCity.DateAtualize;
                var compare = dateNow - dateMysql;
                var compareMinutes = (int)compare.TotalMinutes;

                if (compareMinutes >= 20)
                {
                    var cityResult = await GetCitySearchByApi(city);
                    var result = await UpdateCity(getCity.Id, cityResult);

                    return result;
                }

            }

            return getCity;

        }

        public TemperatureModel GetCity(string request)
        {
            throw new NotImplementedException();
        }

        public string Update(TemperatureModel request)
        {
            throw new NotImplementedException();
        }

        public static async Task<TemperatureModel> GetCitySearchByApi(string city)
        {
            var response = new TemperatureModel();

            using (var client = new HttpClient())
            {
                try
                {

                    client.BaseAddress = new Uri("http://api.openweathermap.org");
                    var result = await client.GetAsync($"/data/2.5/weather?q={city}&appid=9a8f62a62ea4ccad5ee2185f8454c59d&units=metric");
                    result.EnsureSuccessStatusCode();

                    var request = await result.Content.ReadAsStringAsync();
                    var resultRequest = JsonConvert.DeserializeObject<Rootobject>(request);

                    response.DateAtualize = DateTime.Now;
                    response.City = resultRequest.name;
                    response.Temp = resultRequest.main.temp;
                    response.Temp_Max = resultRequest.main.temp_max;
                    response.Temp_Min = resultRequest.main.temp_min;

                    return response;

                }
                catch (Exception )
                {
                    Console.WriteLine("Ops! Cidade Inexistente :(");
                    return null;
                }

                return response;
            }
        }

        public async Task<TemperatureModel> UpdateCity(int id, TemperatureModel model)
        {
            var reponse = new TemperatureModel();
            model.Id = id;

            var citySearch = _temperaturecontext.Set<TemperatureModel>().Local.Where(x => x.Id == id).FirstOrDefault();

            if (citySearch != null)
            {
                _temperaturecontext.Entry(citySearch).State = EntityState.Detached;
            }

            reponse.Id = model.Id;
            reponse.DateAtualize = DateTime.Now;
            reponse.City = model.City;
            reponse.Temp = model.Temp;
            reponse.Temp_Max = model.Temp_Max;
            reponse.Temp_Min = model.Temp_Min;
            _temperaturecontext.TemperatureCitys.Update(reponse);
            _temperaturecontext.SaveChanges();

            return reponse;
        }

        public void Remove(int id)
        {
            var removeCity = _temperaturecontext.TemperatureCitys.Where(x => x.Id == id).FirstOrDefault();
            _temperaturecontext.TemperatureCitys.Remove(removeCity);
            _temperaturecontext.SaveChanges();
        }
    }
}
