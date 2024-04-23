using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyShop.Infrastructure.Repositories;
public abstract class GenericGuidRepository<TEntity, TDbContext>(TDbContext context) : IRepository<TEntity> 
    where TEntity : class
    where TDbContext : DbContext
{
    protected TDbContext Context => context;

    public virtual TEntity Add(TEntity entity)
    {
        return Context
            .Add(entity)
            .Entity;
    }

    public virtual TEntity Get(Guid id)
    {
        return Context.Find<TEntity>(id);
    }

    public virtual TEntity Update(TEntity entity)
    {
        return Context.Update(entity)
            .Entity;
    }

    public virtual void Delete(TEntity entity)
    {
        Context.Remove(entity);
    }

    public virtual IEnumerable<TEntity> All()
    {
        return [.. Context.Set<TEntity>().AsQueryable()];
    }

    public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return [.. Context.Set<TEntity>()
            .AsQueryable()
            .Where(predicate)];
    }

    public int SaveChanges()
    {
        return Context.SaveChanges();
    }
}