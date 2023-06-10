# AuctionApp

## Uygulama Demo 
https://www.youtube.com/watch?v=hk2obq5zB60


### SqlTableDependency
SqlTableDependency, .NET platformunda kullanılabilen bir kütüphanedir. Bu kütüphane, SQL Server veri tabanındaki tablolardaki değişiklikleri algılamak ve bunları dinamik olarak takip etmek için tasarlanmıştır.

SqlTableDependency, veri tabanındaki bir tabloya yapılan ekleme, güncelleme veya silme gibi değişiklikleri izleyerek bu değişiklikleri uygulamanın bir parçası olan uygulamalara anlık olarak bildirir. Bu şekilde, uygulamanın gerçek zamanlı olarak tablodaki veri değişikliklerine tepki vermesi ve ilgili iş mantığını çalıştırması sağlanır.

```c#
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
```
