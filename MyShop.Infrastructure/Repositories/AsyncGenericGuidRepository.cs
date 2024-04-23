using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories;

public abstract class AsyncGenericGuidRepository<TEntity, TDbContext>(TDbContext context) : IAsyncRepository<TEntity>
    where TEntity : class
    where TDbContext : DbContext
{
    protected TDbContext Context => context;

    public virtual async ValueTask<TEntity> AddAsync(TEntity entity)
    {
        EntityEntry<TEntity> result = await Context.AddAsync(entity);
        return result.Entity;
    }

    public virtual async ValueTask<TEntity> GetAsync(Guid id)
    {
        TEntity result = await Context.FindAsync<TEntity>(id);
        return result;
    }

    public virtual TEntity Update(TEntity entity)
    {
        TEntity result = Context.Update(entity).Entity;
        return result;
    }

    public virtual void Delete(TEntity entity)
    {
        var _ = Context.Remove(entity);
    }

    public virtual async IAsyncEnumerable<TEntity> AllAsync()
    {
        IQueryable<TEntity> result = Context.Set<TEntity>().AsQueryable();
        await foreach (TEntity entity in result.AsAsyncEnumerable())
            yield return entity;
    }

    public virtual async IAsyncEnumerable<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        IQueryable<TEntity> result = Context.Set<TEntity>().AsQueryable().Where(predicate);
        await foreach (TEntity entity in result.AsAsyncEnumerable())
            yield return entity;
    }

    public Task<int> SaveChangesAsync()
    {
        Task<int> result = Context.SaveChangesAsync();
        return result;
    }
}
