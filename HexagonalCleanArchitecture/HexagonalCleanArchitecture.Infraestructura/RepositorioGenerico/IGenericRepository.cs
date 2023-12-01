using HexagonalCleanArchitecture.Dominio.Entidades.Base;
using System.Linq.Expressions;

namespace HexagonalCleanArchitecture.Infraestructura.RepositorioGenerico;

public interface IGenericRepository<T> where T : EntidadBase
{
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T?> GetByIdAsync(object id);
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                  string includeProperties = "", bool isTracking = false);
}
