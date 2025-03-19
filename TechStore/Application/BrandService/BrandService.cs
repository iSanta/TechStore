using static TechStore.Application.ICustomService.ICustomService;
using TechStore.Core.Entities;
using TechStore.Domain.Models;
using TechStore.Infrastructure.IRepository;
using TechStore.Domain.Entities;
using System.Security.Cryptography;
using TechStore.Domain.Models.DTO;
using AutoMapper;

namespace TechStore.Application.BrandService
{
    public class BrandService : ICustomService<BrandDto>
    {
        private readonly IRepository<Brand> genericRepository;
        private readonly IMapper mapper;
        public BrandService(IRepository<Brand> _genericRepository, IMapper _mapper)
        {
            genericRepository = _genericRepository;
            mapper = _mapper;
        }

        public BaseResponse<BrandDto> ChangeState(int _id)
        {
            try
            {
                BaseResponse<BrandDto> response = new BaseResponse<BrandDto>();
                Brand entity = genericRepository.Get(_id);
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
                    response.StatusMessage = "Brand with id " + _id + " not found";
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BaseResponse<BrandDto> Get(int _id)
        {
            try
            {
                BaseResponse<BrandDto> response = new BaseResponse<BrandDto>();
                var obj = genericRepository.Get(_id, p => p.Products);
                if (obj != null)
                {
                    var mappedObj = mapper.Map<BrandDto>(obj);
                    response.objectResponse = mappedObj;
                }
                else
                {
                    response.Status = false;
                    response.StatusMessage = "Brand with id " + _id + " not found";
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BaseResponse<IEnumerable<BrandDto>> GetAll()
        {
            try
            {
                BaseResponse<IEnumerable<BrandDto>> response = new BaseResponse<IEnumerable<BrandDto>>();
                var obj = genericRepository.GetAll(p => p.Products).ToList();
                if (obj != null)
                {
                    var mappedObj = mapper.Map<IEnumerable<BrandDto>>(obj);
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

        public BaseResponse<BrandDto> Insert(object _create)
        {
            try
            {
                BaseResponse<BrandDto> response = new BaseResponse<BrandDto>();
                BrandCreateRequest brand = (BrandCreateRequest)_create;
                Brand entity = new Brand();
                entity.Description = brand.Description;
                entity.BrandName = brand.BrandName;
                genericRepository.Insert(entity);
                genericRepository.SaveChanges();
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BaseResponse<BrandDto> Remove(int _id)
        {
            try
            {
                BaseResponse<BrandDto> response = new BaseResponse<BrandDto>();
                Brand entity = genericRepository.Get(_id);
                if (entity != null)
                {
                    genericRepository.Remove(entity);
                    genericRepository.SaveChanges();
                }
                else
                {
                    response.Status = false;
                    response.StatusMessage = "Brand with id " + _id + " not found";
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BaseResponse<BrandDto> Update(object _update)
        {
            try
            {
                BaseResponse<BrandDto> response = new BaseResponse<BrandDto>();
                BrandUpdateRequest brand = (BrandUpdateRequest)_update;
                Brand entity = genericRepository.Get(brand.Id ?? -1);
                if (entity != null)
                {
                    entity.Description = brand.Description != null ? brand.Description : entity.Description;
                    entity.BrandName = brand.BrandName != null ? brand.BrandName : entity.BrandName;
                    entity.ModifiedDate = DateTime.Now;
                    genericRepository.Update(entity);
                    genericRepository.SaveChanges();
                }
                else
                {
                    response.Status = false;
                    response.StatusMessage = "Brand with id " + brand.Id + " not found";
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
