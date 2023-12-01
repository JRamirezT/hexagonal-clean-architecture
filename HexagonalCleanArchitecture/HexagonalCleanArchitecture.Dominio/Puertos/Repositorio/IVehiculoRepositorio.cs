using HexagonalCleanArchitecture.Dominio.Entidades;
using System.Linq.Expressions;

namespace HexagonalCleanArchitecture.Dominio.Puertos.Repositorio;

public interface IVehiculoRepositorio
{
    Task<Vehiculo> AddAsync(Vehiculo entidad);
    Task UpdateAsync(Vehiculo entidad);
    Task DeleteAsync(Vehiculo entidad);
    Task<Vehiculo?> GetByIdAsync(object id);
    Task<IEnumerable<Vehiculo>> GetAsync(Expression<Func<Vehiculo, bool>>? filtro = null, Func<IQueryable<Vehiculo>, IOrderedQueryable<Vehiculo>>? orderBy = null,
                                         string includeProperties = "", bool isTracking = false);
}
