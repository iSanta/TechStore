using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TechStore.Domain.Data;
using TechStore.Domain.Models;
using TechStore.Infrastructure.IRepository;

namespace TechStore.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region property
        private readonly DataContext _applicationDbContext;
        private DbSet<T> entities;
        #endregion
        #region Constructor
        public Repository(DataContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
        }
        #endregion
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public T Get(int Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includedProperties)
        {
            IQueryable<T> query = entities;
            foreach (var includedProperty in includedProperties)
            {
                query = query.Include(includedProperty);
            }
            return [.. query];
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
        
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entity.ModifiedDate = DateTime.UtcNow;
            entities.Update(entity);
            _applicationDbContext.SaveChanges();
        }

    }
}
