﻿// <auto-generated />
using System;
using CityTemperature.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CityTemperature.Migrations
{
    [DbContext(typeof(TemperatureContext))]
    partial class TemperatureContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CityTemperature.Models.TemperatureModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<DateTime>("DateAtualize");

                    b.Property<float>("Temp");

                    b.Property<float>("Temp_Max");

                    b.Property<float>("Temp_Min");

                    b.HasKey("Id");

                    b.ToTable("TemperatureCitys");
                });
#pragma warning restore 612, 618
        }
    }
}