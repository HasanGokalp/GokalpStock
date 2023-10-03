using System.Linq.Expressions;

namespace GokalpStock.Persistence.Abstract.Repository
{
    public interface IRepository<T> 
        where T : class
    {
        //CRUD OPERATIONS
        void Insert(T entity);
        void Update(T entity); 
        void Delete(T entity);

        #region GetAlls

        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        #endregion

        #region GetByFilter

        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter = null);
        Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter = null);
        #endregion

        #region GetByIds

        T GetById(int id);
        Task<T> GetByIdAsync(int id);

        #endregion
    }
}
