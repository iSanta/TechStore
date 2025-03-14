namespace TechStore.Application.ICustomService
{
    public interface ICustomService
    {
        public interface ICustomService<T> where T : class
        {
            IEnumerable<T> GetAll();
            T Get(int Id);
            void Insert(T entity);
            void Update(T entity);
            void Delete(T entity);
            void Remove(T entity);
        }
    }
}
