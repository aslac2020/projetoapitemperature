using CityTemperature.Models;
using CityTemperature.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static CityTemperature.Models.CityModels;

namespace CityTemperature.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : Controller
    {
        private readonly ITemperatureRepositories _repositories;
        public TemperatureController(ITemperatureRepositories repositories)
        {
            _repositories = repositories;
        }

        [HttpGet]
        public async Task<IActionResult> GetTemperatureCity(string city)
        {
            var response = await _repositories.Add(city);

            if (response == null)
            {
               return BadRequest("Ops! Cidade não encontrada :(");
            }

            return Ok(response);

        }

        [HttpDelete("{id}")]
        public IActionResult CityDelete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id não encontrado :(");
            }

            var request = new TemperatureModel();
            request.Id = id;
            _repositories.Remove(id);

            return Ok(id);
        }

    }
}

