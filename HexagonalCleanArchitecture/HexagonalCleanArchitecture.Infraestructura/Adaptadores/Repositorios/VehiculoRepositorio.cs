using HexagonalCleanArchitecture.Dominio.Entidades;
using HexagonalCleanArchitecture.Dominio.Puertos.Repositorio;
using HexagonalCleanArchitecture.Infraestructura.RepositorioGenerico;
using System.Linq.Expressions;

namespace HexagonalCleanArchitecture.Infraestructura.Adaptadores.Repositorios;

public class VehiculoRepositorio : IVehiculoRepositorio
{
    readonly IGenericRepository<Vehiculo> _repositorio;

    public VehiculoRepositorio(IGenericRepository<Vehiculo> repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<Vehiculo> AddAsync(Vehiculo entidad)
    {
        return await _repositorio.AddAsync(entidad);
    }

    public async Task DeleteAsync(Vehiculo entidad)
    {
        await _repositorio.DeleteAsync(entidad);
    }

    public async Task<Vehiculo> GetByIdAsync(object id)
    {
        return await _repositorio.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Vehiculo>> GetAsync(Expression<Func<Vehiculo, bool>>? filtro = null, Func<IQueryable<Vehiculo>, IOrderedQueryable<Vehiculo>>? orderBy = null, string includeProperties = "", bool isTracking = false)
    {
        return await _repositorio.GetAsync(filtro, orderBy, includeProperties, isTracking);
    }

    public async Task UpdateAsync(Vehiculo entidad)
    {
        await _repositorio.UpdateAsync(entidad);
    }
}

