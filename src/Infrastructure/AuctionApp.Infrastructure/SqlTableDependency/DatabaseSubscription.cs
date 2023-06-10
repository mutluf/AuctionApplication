using AuctionApp.Application.DTOs;
using AuctionApp.Domain.Entities;
using AuctionApp.Infrastructure.Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using TableDependency.SqlClient;

namespace AuctionApp.Infrastructure.SqlTableDependency
{
    public interface IDatabaseSubscription
    {
        void Configure(string tableName);
    }
    public class DatabaseSubscription<T> : IDatabaseSubscription where T : class, new()
    {
        SqlTableDependency<T> _tableDependency;
        IConfiguration _configuration;
        IHubContext<OfferHub> _hubContext;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        

        public DatabaseSubscription(IConfiguration configuration, IHubContext<OfferHub> hubContext, IServiceScopeFactory serviceScopeFactory)
        {
            _configuration = configuration;
            _hubContext = hubContext;
            _serviceScopeFactory = serviceScopeFactory;            
        }

        public void Configure(string tableName)
        {
            _tableDependency = new SqlTableDependency<T>(_configuration.GetConnectionString("DefaultConnection"), tableName);
            _tableDependency.OnChanged += async (o, e) =>
            {
                List<Offer> datas;
                T dataBack = new T();
                UserManager<AppUser> _userManager;
                Offer offer = null;
                AppUser user = null;
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                     _userManager = scope.ServiceProvider.GetService<UserManager<AppUser>>();
                    dataBack = e.Entity;

                     offer = (Offer)Convert.ChangeType(dataBack, typeof(Offer));
                     user = await _userManager.FindByIdAsync(offer.UserId.ToString());
                }               

                OfferUserDTO dto = new OfferUserDTO
                {
                    OfferPrice = offer.OfferPrice,
                    AuctionId = offer.AuctionId,
                    UserId = user.Id,
                    UserName=user.UserName
                };

                string jsonData = JsonSerializer.Serialize(dto);
                await _hubContext.Clients.All.SendAsync("receiveMessage", jsonData);


            };
            _tableDependency.OnError += (o, e) =>
            {

            };
            _tableDependency.Start();
        }

        ~DatabaseSubscription()
        {
            _tableDependency.Stop();
        }
    }
}
