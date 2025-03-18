using TechStore.Core.Entities;
using TechStore.Domain.Entities;

namespace TechStore.Application.ICustomService
{
    public interface ICustomService
    {
        public interface ICustomService<T> where T : class
        {
            BaseResponse<IEnumerable<T>>  GetAll();
            BaseResponse<T> Get(int Id);
            BaseResponse<T> Insert(object _create);
            BaseResponse<T> Update(object _update);
            BaseResponse<T> Remove(int Id);
            BaseResponse<T> ChangeState(int _d);
        }
    }
}
