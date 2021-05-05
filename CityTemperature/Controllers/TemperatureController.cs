using CityTemperature.Borders.Interfaces;
using CityTemperature.Borders.UseCase;
using CityTemperature.DTO;
using CityTemperature.DTO.GetCitys;
using CityTemperature.Models;
using CityTemperature.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static CityTemperature.Models.CityModels;

namespace CityTemperature.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ILogger<TemperatureController> _logger;
        private readonly ITemperatureRepositories _repositories;
        private readonly IAddCitysUseCase _addCitysUseCase;
        private readonly IGetCitysUseCase _getCitysUseCase;

        public TemperatureController(ILogger<TemperatureController> logger, 
            IAddCitysUseCase addCitysUseCase, ITemperatureRepositories repositories, IGetCitysUseCase getCitysUse)
        {
            _repositories = repositories;
            _logger = logger;
            _addCitysUseCase = addCitysUseCase;
            _getCitysUseCase = getCitysUse;
        }

        [HttpPost]
        public IActionResult AddGetCitys([FromBody] AddCitysRequest citys)
        {
            return Ok(_addCitysUseCase.Execute(citys));
        }

        [HttpGet]
        public async Task<IActionResult> GetTemperatureCity(string city)
        {

            if (city == null)
            {
               return BadRequest("Ops! Cidade não encontrada :(");
            }

            var request = new GetCitysRequest();
            request.city = city;
            return Ok( await _getCitysUseCase.Execute(request));

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

