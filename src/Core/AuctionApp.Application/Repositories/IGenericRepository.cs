using AuctionApp.Domain.Entities.Common;
using System.Linq.Expressions;

namespace AuctionApp.Application.Repositories
{
    public interface IGenericRepository<T>:IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
        Task<T> GetByIdAysnc(string id);
        Task<T> GetSingleAysnc(Expression<Func<T, bool>> method);
        Task<bool> AddAysnc(T Model);
        bool Update(T Model);
        Task<int> SaveAysnc();
        void Delete(T Model);
    }
}
