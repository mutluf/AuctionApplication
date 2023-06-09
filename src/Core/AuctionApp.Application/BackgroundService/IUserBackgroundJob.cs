using AuctionApp.Domain.Entities;

namespace AuctionApp.Application.BackgroundService
{
    public interface IUserBackgroundJob:IBackgroundJob<AppUser>
    {
    }
}
