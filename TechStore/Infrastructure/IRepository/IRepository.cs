using System.Linq.Expressions;
using TechStore.Domain.Models;

namespace TechStore.Infrastructure.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includedProperties);
        T Get(int Id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
