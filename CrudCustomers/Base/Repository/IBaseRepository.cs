using CrudCustomers.Base.Model;

namespace CrudCustomers.Base.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseModel
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll(int page, int pageSize);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
