using HexagonalCleanArchitecture.Dominio.Entidades.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HexagonalCleanArchitecture.Infraestructura.RepositorioGenerico;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntidadBase
{
    internal HexagonalContext context;
    internal DbSet<TEntity> dbSet;

    public GenericRepository(HexagonalContext context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>,
                                                             IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "",
                                                             bool isTracking = false)
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            _ = orderBy(query);
        }

        if (isTracking)
        {
            return await query.ToListAsync();
        }
        else
        {
            return await query.AsNoTracking().ToListAsync();
        }
    }

    public virtual async Task<TEntity?> GetByIdAsync(object id)
    {
        return await dbSet.FindAsync(id);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        dbSet.Remove(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        dbSet.Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
        entity.FechaActualizacion = DateTime.UtcNow;
        await context.SaveChangesAsync();
    }
}
