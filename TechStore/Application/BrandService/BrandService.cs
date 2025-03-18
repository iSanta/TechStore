using static TechStore.Application.ICustomService.ICustomService;
using TechStore.Core.Entities;
using TechStore.Domain.Models;
using TechStore.Infrastructure.IRepository;
using TechStore.Domain.Entities;
using System.Security.Cryptography;

namespace TechStore.Application.BrandService
{
    public class BrandService : ICustomService<Brand>
    {
        private readonly IRepository<Brand> genericRepository;

        public BrandService(IRepository<Brand> _genericRepository)
        {
            genericRepository = _genericRepository;
        }

        public BaseResponse<Brand> ChangeState(int _id)
        {
            try
            {
                BaseResponse<Brand> response = new BaseResponse<Brand>();
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

        public BaseResponse<Brand> Get(int _id)
        {
            try
            {
                BaseResponse<Brand> response = new BaseResponse<Brand>();
                var obj = genericRepository.Get(_id);
                if (obj != null)
                {
                    response.objectResponse = obj;
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

        public BaseResponse<IEnumerable<Brand>> GetAll()
        {
            try
            {
                BaseResponse<IEnumerable<Brand>> response = new BaseResponse<IEnumerable<Brand>>();
                var obj = genericRepository.GetAll();
                if (obj != null)
                {
                    response.objectResponse = obj;
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

        public BaseResponse<Brand> Insert(object _create)
        {
            try
            {
                BaseResponse<Brand> response = new BaseResponse<Brand>();
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

        public BaseResponse<Brand> Remove(int _id)
        {
            try
            {
                BaseResponse<Brand> response = new BaseResponse<Brand>();
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

        public BaseResponse<Brand> Update(object _update)
        {
            try
            {
                BaseResponse<Brand> response = new BaseResponse<Brand>();
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
