using AuctionApp.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }

}
