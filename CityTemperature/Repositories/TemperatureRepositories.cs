using CityTemperature.Borders.Interfaces;
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

        public async Task<TemperatureModel> Add(TemperatureModel city)
        {
            _temperaturecontext.TemperatureCitys.Add(city);
            _temperaturecontext.SaveChanges();
            return city;
        }


        public TemperatureModel GetCity(string city)
        {
            var response = new TemperatureModel();

            return _temperaturecontext.TemperatureCitys.Where(x => x.City == city).FirstOrDefault();
        }

        public void Update(TemperatureModel request, int id)
        {

            request.Id = id;
            var citySearch = _temperaturecontext.Set<TemperatureModel>().Local.Where(x => x.Id == id).FirstOrDefault();

            if (citySearch != null)
                _temperaturecontext.Entry(citySearch).State = EntityState.Detached;

            _temperaturecontext.TemperatureCitys.Update(request);
            _temperaturecontext.SaveChanges();

        }

        public void Remove(int id)
        {
            var removeCity = _temperaturecontext.TemperatureCitys.Where(x => x.Id == id).FirstOrDefault();
            _temperaturecontext.TemperatureCitys.Remove(removeCity);
            _temperaturecontext.SaveChanges();
        }

    }
}
