using System.Linq.Expressions;
using Core.Consts;

namespace Core.Interfaces
{
    public interface IBaseRepository<T>
        where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);

        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        T Find(Expression<Func<T, bool>> criteria);
        T Find(Expression<Func<T, bool>> criteria, string[] includes = null);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take, int skip);
        IEnumerable<T> FindAll(
            Expression<Func<T, bool>> criteria,
            int? take,
            int? skip,
            Expression<Func<T, object>> orderBy = null,
            string orderByDirection = OrderBy.Ascending
        );

        // ----------------
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
    }
}
