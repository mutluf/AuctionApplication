using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AuctionApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AuctionApp.Persistence.Context;
using Microsoft.AspNetCore.Identity;

namespace AuctionApp.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAuctionRepository, AuctionRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IAppUserAuctionRepository, AppUserAuctionRepository>();
          
        }
    }

    public static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager cfg = new ConfigurationManager();
                cfg.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/AuctionApp"));
                cfg.AddJsonFile("appsettings.json");//microsoft.extensions.configuration.json adındaki paket üst 2 satır için gerekli. çok gerekli

                return cfg.GetConnectionString("MicrosoftSQL");
            }
        }
    }
}
