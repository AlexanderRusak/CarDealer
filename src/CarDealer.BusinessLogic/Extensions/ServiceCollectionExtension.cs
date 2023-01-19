using CarDealer.DataAccess.Context;
using CarDealer.DataAccess.Model.Repositories.Interfaces;
using CarDealer.DataAccess.Model.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealer.BusinessLogic.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddBuisnessServices(this IServiceCollection services)
        {
            services.AddSingleton(new CarDealerContext());
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IDealerCarRepository, DealerCarRepository>();
            services.AddScoped<IDealerRepository, DealerRepository>();
        }

    }
}
