using CityTemperature.Models;
using System.Threading.Tasks;

namespace CityTemperature.Borders.Interfaces
{
    public interface ITemperatureRepositories
    {
        public Task<TemperatureModel> Add(TemperatureModel city);
        public TemperatureModel GetCity(string city);
        public void Update(TemperatureModel request, int id);
        public void Remove(int id);
    }
}