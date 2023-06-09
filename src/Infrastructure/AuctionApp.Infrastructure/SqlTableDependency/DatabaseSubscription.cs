using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AuctionApp.Infrastructure.Hubs;
using TableDependency.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

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
        IHubContext<ProductHub> _hubContext;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        


        public DatabaseSubscription(IConfiguration configuration, IHubContext<ProductHub> hubContext, IServiceScopeFactory serviceScopeFactory)
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
                //List<Product> datas;
                List<Offer> datas;
                T dataBack = new T();
                UserManager<AppUser> _userManager;
                Offer offer = null;
                AppUser user = null;
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                     _userManager = scope.ServiceProvider.GetService<UserManager<AppUser>>();


                    //datas= myScopedService.GetAll().ToList();
                    //var datas2 = myScopedService.GetAll().Include(data => data.Category);
                    //foreach (var item in datas2)
                    //{
                    //    item.CategoryName = item.Category.CategoryName;
                    //}
                    //datas = datas2.ToList();


                    dataBack = e.Entity;


                    //datas = myScopedService.GetAll().ToList();
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
class OfferUserDTO
{
    public int OfferPrice { get; set; }
    public string UserName { get; set; }
    public int AuctionId { get; set; } 
    public int UserId { get; set; }
}
