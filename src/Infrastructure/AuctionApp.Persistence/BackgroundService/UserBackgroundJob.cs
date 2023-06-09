using AuctionApp.Domain.Entities;
using Hangfire;
using AuctionApp.Application.BackgroundService;

namespace AuctionApp.Persistence.BackgroundService
{
    public class UserBackgroundJob : BackgroundJob<AppUser>, IUserBackgroundJob
    {
        public UserBackgroundJob(IBackgroundJobClient backgroundJobClient) : base(backgroundJobClient)
        {
        }
    }
}
