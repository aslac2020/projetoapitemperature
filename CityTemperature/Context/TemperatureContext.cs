using CityTemperature.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperature.Context
{
    public class TemperatureContext : DbContext
    {
        public TemperatureContext(DbContextOptions<TemperatureContext> options)
          : base(options)
        { }

        public DbSet<TemperatureModel> TemperatureCitys { get; set; }
       
    }
}
