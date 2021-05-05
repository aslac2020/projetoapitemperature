using CityTemperature.Adapter;
using CityTemperature.Borders.Adapter;
using CityTemperature.Borders.Interfaces;
using CityTemperature.Borders.UseCase;
using CityTemperature.Context;
using CityTemperature.Repositories;
using CityTemperature.UseCase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CityTemperature
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TemperatureContext>(options => options.UseMySql(Configuration.GetConnectionString("TemperatureConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IAddCitysUseCase, AddCitysUseCase>();
            services.AddScoped<IGetCitysUseCase, GetCitysUseCase>();

            services.AddScoped<ITemperatureRepositories, TemperatureRepositories>();


            services.AddScoped<IAddCitysAdapter, AddCitysAdapter>();
            services.AddScoped<IGetCitysAdapter, GetCitysAdapter>();
            services.AddScoped<ISearchCityApiAdapter, SearchCityApiAdapter>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Temperatura de Cidades", Description = "Temperaturas", Version = "1.0" });

                c.EnableAnnotations();

                c.DescribeAllEnumsAsStrings();
                c.DescribeAllParametersInCamelCase();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Versão 1.0");
            });


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
