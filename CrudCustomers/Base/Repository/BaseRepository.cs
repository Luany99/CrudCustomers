using CrudCustomers.Base.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudCustomers.Base.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task Add(TEntity entity) => await _dbSet.AddAsync(entity);

        public async Task<TEntity> GetById(int id) => await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<TEntity>> GetAll(int page, int pageSize)
        {
            return await _dbSet
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }
    }
}
