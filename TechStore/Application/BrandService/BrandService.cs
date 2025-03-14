using static TechStore.Application.ICustomService.ICustomService;
using TechStore.Core.Entities;
using TechStore.Domain.Models;
using TechStore.Infrastructure.IRepository;

namespace TechStore.Application.BrandService
{
    public class BrandService : ICustomService<Brand>
    {
        private readonly IRepository<Brand> genericRepository;

        public BrandService(IRepository<Brand> _genericRepository)
        {
            genericRepository = _genericRepository;
        }
        public void Delete(Brand entity)
        {
            throw new NotImplementedException();
        }

        public Brand Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brand> GetAll()
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

        public void Insert(Brand entity)
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

        public void Remove(Brand entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand entity)
        {
            throw new NotImplementedException();
        }
    }
}
