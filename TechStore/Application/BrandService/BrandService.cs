using static TechStore.Application.ICustomService.ICustomService;
using TechStore.Core.Entities;
using TechStore.Domain.Models;
using TechStore.Infrastructure.IRepository;
using TechStore.Domain.Entities;

namespace TechStore.Application.BrandService
{
    public class BrandService : ICustomService<Brand>
    {
        private readonly IRepository<Brand> genericRepository;

        public BrandService(IRepository<Brand> _genericRepository)
        {
            genericRepository = _genericRepository;
        }

        public BaseResponse<Brand> ChangeState(int Id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<Brand> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<IEnumerable<Brand>> GetAll()
        {
            throw new NotImplementedException();
        }

        public BaseResponse<Brand> Insert(object _create)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<Brand> Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<Brand> Update(object _update)
        {
            throw new NotImplementedException();
        }
    }
}
