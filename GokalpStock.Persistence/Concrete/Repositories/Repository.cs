using GokalpStock.Domain.Abstract;
using GokalpStock.Persistence.Abstract.Repository;
using GokalpStock.Persistence.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace GokalpStock.Persistence.Concrete.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;
        private readonly GokalpStockContext _context;
        public Repository(GokalpStockContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter = null)
        {
            return _dbSet.Where(filter);
        }

        public async Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter = null)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public T GetById(int id)
        {
            var entity = _dbSet.Find(id);
            return entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();

        }
    }
}
