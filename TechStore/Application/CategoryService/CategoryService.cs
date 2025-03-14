using TechStore.Core.Entities;
using TechStore.Infrastructure.IRepository;
using static TechStore.Application.ICustomService.ICustomService;

namespace TechStore.Application.CategoryService
{
    public class CategoryService : ICustomService<Category>
    {
        private readonly IRepository<Category> genericRepository;

        public CategoryService(IRepository<Category> _genericRepository)
        {
            genericRepository = _genericRepository;
        }

        public void Delete(Category entity)
        {
            try
            {
                if (entity != null)
                {
                    genericRepository.Delete(entity);
                    genericRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Category Get(int Id)
        {
            try
            {
                var obj = genericRepository.Get(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Category> GetAll()
        {
            try
            {
                var obj = genericRepository.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(Category entity)
        {
            try
            {
                if (entity != null)
                {
                    genericRepository.Insert(entity);
                    genericRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(Category entity)
        {
            try
            {
                if (entity != null)
                {
                    genericRepository.Remove(entity);
                    genericRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Category entity)
        {
            try
            {
                if (entity != null)
                {
                    genericRepository.Update(entity);
                    genericRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
