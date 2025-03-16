using TechStore.Core.Entities;
using TechStore.Domain.Entities;
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

        public BaseResponse<Category> ChangeState(int _id)
        {
            try
            {
                BaseResponse<Category> response = new BaseResponse<Category>();
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

        public BaseResponse<Category> Get(int _id)
        {
            try
            {
                BaseResponse<Category> response = new BaseResponse<Category>();
                var obj = genericRepository.Get(_id);
                if (obj != null)
                {
                    response.objectResponse = obj;
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

        public BaseResponse<IEnumerable<Category>> GetAll()
        {
            try
            {
                BaseResponse<IEnumerable<Category>> response = new BaseResponse<IEnumerable<Category>>();
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

        public BaseResponse<Category> Insert(object _category)
        {
            try
            {
                BaseResponse<Category> response = new BaseResponse<Category>();
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

        public BaseResponse<Category> Remove(int _id)
        {
            try
            {
                BaseResponse<Category> response = new BaseResponse<Category>();
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

        public BaseResponse<Category> Update(object _category)
        {
            try
            {
                BaseResponse<Category> response = new BaseResponse<Category>();
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
