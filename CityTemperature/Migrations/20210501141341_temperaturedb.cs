using Microsoft.EntityFrameworkCore.Migrations;

namespace CityTemperature.Migrations
{
    public partial class temperaturedb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(" Insert into temperaturecitys(City, Temp, Temp_min, Temp_max, DateAtualize) " +
                "Values('Caieiras', 20.24, 21.67, 19, now())");
        }

        protected override void Down(MigrationBuilder mb)
        {

        }
    }
}
