using static TechStore.Application.ICustomService.ICustomService;
using TechStore.Domain.Models;
using TechStore.Infrastructure.IRepository;
using TechStore.Domain.Entities;
using System.Security.Cryptography;
using TechStore.Core.Entities;
using AutoMapper;
using TechStore.Domain.Models.DTO;

namespace TechStore.Application.ProductService
{
    public class ProductService : ICustomService<ProductDto>
    {
        private readonly IRepository<Product> genericRepository;
        private readonly IMapper mapper;

        public ProductService(IRepository<Product> _genericRepository, IMapper _mapper)
        {
            genericRepository = _genericRepository;
            mapper = _mapper;
        }

        public BaseResponse<IEnumerable<ProductDto>> GetAll()
        {
            try
            {
                BaseResponse<IEnumerable<ProductDto>> response = new BaseResponse<IEnumerable<ProductDto>>();
                var obj = genericRepository.GetAll(p => p.Brand, p => p.Category).ToList();
                if (obj != null)
                {
                    var mappedObj = mapper.Map<IEnumerable<ProductDto>>(obj);
                    response.objectResponse = mappedObj;
                }
                else
                {
                    response.Status = false;
                    response.StatusMessage = "Not results found";
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BaseResponse<ProductDto> Insert(object _create)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<ProductDto> Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<ProductDto> Update(object _update)
        {
            throw new NotImplementedException();
        }

        BaseResponse<ProductDto> ICustomService<ProductDto>.ChangeState(int _d)
        {
            throw new NotImplementedException();
        }

        BaseResponse<ProductDto> ICustomService<ProductDto>.Get(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
