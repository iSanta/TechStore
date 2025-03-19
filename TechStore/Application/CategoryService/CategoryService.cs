using AutoMapper;
using TechStore.Core.Entities;
using TechStore.Domain.Entities;
using TechStore.Domain.Models.DTO;
using TechStore.Infrastructure.IRepository;
using static TechStore.Application.ICustomService.ICustomService;

namespace TechStore.Application.CategoryService
{
    public class CategoryService : ICustomService<CategoryDto>
    {
        private readonly IRepository<Category> genericRepository;
        private readonly IMapper mapper;
        public CategoryService(IRepository<Category> _genericRepository, IMapper _mapper)
        {
            genericRepository = _genericRepository;
            mapper = _mapper;
        }

        public BaseResponse<CategoryDto> ChangeState(int _id)
        {
            try
            {
                BaseResponse<CategoryDto> response = new BaseResponse<CategoryDto>();
                Category entity = genericRepository.Get(_id);
                if (entity != null) { 
                    entity.IsActive = !entity.IsActive;
                    entity.ModifiedDate = DateTime.Now;
                    genericRepository.Update(entity);
                    genericRepository.SaveChanges();
                }
                else
                {
                    response.Status = false;
                    response.StatusMessage = "Category with id " + _id + " not found";
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BaseResponse<CategoryDto> Get(int _id)
        {
            try
            {
                BaseResponse<CategoryDto> response = new BaseResponse<CategoryDto>();
                var obj = genericRepository.Get(_id, p => p.Products);
                if (obj != null)
                {
                    var mappedObj = mapper.Map<CategoryDto>(obj);
                    response.objectResponse = mappedObj;
                }
                else
                {
                    response.Status = false;
                    response.StatusMessage = "Category with id " + _id + " not found";
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BaseResponse<IEnumerable<CategoryDto>> GetAll()
        {
            try
            {
                BaseResponse<IEnumerable<CategoryDto>> response = new BaseResponse<IEnumerable<CategoryDto>>();
                var obj = genericRepository.GetAll(p => p.Products).ToList();
                if (obj != null)
                {
                    var mappedObj = mapper.Map<IEnumerable<CategoryDto>>(obj);
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

        public BaseResponse<CategoryDto> Insert(object _category)
        {
            try
            {
                BaseResponse<CategoryDto> response = new BaseResponse<CategoryDto>();
                CategoryCreateRequest category = (CategoryCreateRequest)_category;
                Category entity = new Category();
                entity.Description = category.Description;
                entity.CategoryName = category.CategoryName;
                genericRepository.Insert(entity);
                genericRepository.SaveChanges();
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BaseResponse<CategoryDto> Remove(int _id)
        {
            try
            {
                BaseResponse<CategoryDto> response = new BaseResponse<CategoryDto>();
                Category entity = genericRepository.Get(_id);
                if (entity != null)
                {
                    genericRepository.Remove(entity);
                    genericRepository.SaveChanges();
                }
                else
                {
                    response.Status = false;
                    response.StatusMessage = "Category with id " + _id + " not found";
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BaseResponse<CategoryDto> Update(object _category)
        {
            try
            {
                BaseResponse<CategoryDto> response = new BaseResponse<CategoryDto>();
                CategoryUpdateRequest category = (CategoryUpdateRequest)_category;
                Category entity = genericRepository.Get(category.Id ?? -1);
                if (entity != null)
                {
                    entity.Description = category.Description != null ? category.Description : entity.Description;
                    entity.CategoryName = category.CategoryName != null ? category.CategoryName : entity.CategoryName;
                    entity.ModifiedDate = DateTime.Now;
                    genericRepository.Update(entity);
                    genericRepository.SaveChanges();
                }
                else
                {
                    response.Status = false;
                    response.StatusMessage = "Category with id " + category.Id + " not found";
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
