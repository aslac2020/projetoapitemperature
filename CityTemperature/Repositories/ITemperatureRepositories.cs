using CityTemperature.Models;
using System.Threading.Tasks;

namespace CityTemperature.Repositories
{
    public interface ITemperatureRepositories
    {
        public Task<TemperatureModel> Add(string request);
        public string Update(TemperatureModel request);
        public TemperatureModel GetCity(string request);
        public void Remove(int id);
    }
}