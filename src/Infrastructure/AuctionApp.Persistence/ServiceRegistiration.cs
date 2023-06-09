using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AuctionApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AuctionApp.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using AuctionApp.Application.BackgroundService;
using AuctionApp.Persistence.BackgroundService;
using Hangfire;

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
            services.AddScoped<IUserBackgroundJob, UserBackgroundJob>();

            services.AddHangfire(configuration => configuration
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseSqlServerStorage(Configuration.ConnectionString));

            services.AddHangfireServer();
        }
    }

    public static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager cfg = new ConfigurationManager();
                cfg.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/AuctionApp.Web"));
                cfg.AddJsonFile("appsettings.json");//microsoft.extensions.configuration.json adındaki paket üst 2 satır için gerekli. çok gerekli

                return cfg.GetConnectionString("DefaultConnection");
            }
        }
    }
}
