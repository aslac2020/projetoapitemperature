using CityTemperature.Borders.Adapter;
using CityTemperature.DTO.GetCitys;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static CityTemperature.Models.CityModels;

namespace CityTemperature.Adapter
{
    public class SearchCityApiAdapter : ISearchCityApiAdapter
    {
        public async Task<GetCitysResponse> GetTemperatureCityApi(string city)
        {
            var response = new GetCitysResponse();

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
                    response.City = city;
                    response.Temp = resultRequest.main.temp;
                    response.Temp_Max = resultRequest.main.temp_max;
                    response.Temp_Min = resultRequest.main.temp_min;

                    return response;

                }
                catch (Exception)
                {
                    Console.WriteLine("Ops! Cidade Inexistente :(");
                    return response;
                }
            }
        }
    }
}
