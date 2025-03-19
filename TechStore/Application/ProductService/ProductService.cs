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
            try
            {
                BaseResponse<ProductDto> response = new BaseResponse<ProductDto>();
                ProductCreateRequest product = (ProductCreateRequest)_create;
                Product entity = new Product();
                entity.Description = product.Description;
                entity.ProductName = product.ProductName;
                entity.Price = product.Price ?? 0;
                entity.IDBrand = product.IDBrand;
                entity.IDCategory = product.IDCategory;
                genericRepository.Insert(entity);
                genericRepository.SaveChanges();
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BaseResponse<ProductDto> Remove(int _id)
        {
            try
            {
                BaseResponse<ProductDto> response = new BaseResponse<ProductDto>();
                Product entity = genericRepository.Get(_id);
                if (entity != null)
                {
                    genericRepository.Remove(entity);
                    genericRepository.SaveChanges();
                }
                else
                {
                    response.Status = false;
                    response.StatusMessage = "Product with id " + _id + " not found";
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BaseResponse<ProductDto> Update(object _update)
        {
            try
            {
                BaseResponse<ProductDto> response = new BaseResponse<ProductDto>();
                ProductUpdateRequest product = (ProductUpdateRequest)_update;
                Product entity = genericRepository.Get(product.Id ?? -1);
                if (entity != null)
                {
                    entity.Description = product.Description != null ? product.Description : entity.Description;
                    entity.ProductName = product.ProductName != null ? product.ProductName : entity.ProductName;
                    entity.Price = (int)(product.Price != null ? product.Price : entity.Price);
                    entity.IDBrand = product.IDBrand != null ? product.IDBrand : entity.IDBrand;
                    entity.IDCategory = product.IDCategory != null ? product.IDCategory : entity.IDCategory;
                    entity.ModifiedDate = DateTime.Now;
                    genericRepository.Update(entity);
                    genericRepository.SaveChanges();
                }
                else
                {
                    response.Status = false;
                    response.StatusMessage = "Product with id " + product.Id + " not found";
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        BaseResponse<ProductDto> ICustomService<ProductDto>.ChangeState(int _id)
        {
            try
            {
                BaseResponse<ProductDto> response = new BaseResponse<ProductDto>();
                Product entity = genericRepository.Get(_id);
                if (entity != null)
                {
                    entity.IsActive = !entity.IsActive;
                    entity.ModifiedDate = DateTime.Now;
                    genericRepository.Update(entity);
                    genericRepository.SaveChanges();
                }
                else
                {
                    response.Status = false;
                    response.StatusMessage = "Product with id " + _id + " not found";
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        BaseResponse<ProductDto> ICustomService<ProductDto>.Get(int _id)
        {
            try
            {
                BaseResponse<ProductDto> response = new BaseResponse<ProductDto>();
                var obj = genericRepository.Get(_id, [p => p.Brand, p => p.Category]);
                if (obj != null)
                {
                    var mappedObj = mapper.Map<ProductDto>(obj);
                    response.objectResponse = mappedObj;
                }
                else
                {
                    response.Status = false;
                    response.StatusMessage = "Product with id " + _id + " not found";
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
