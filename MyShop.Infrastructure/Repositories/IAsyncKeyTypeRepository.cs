using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories;

public interface IAsyncKeyTypeRepository<TEntity, TKeyType> where TKeyType : struct
{
    ValueTask<TEntity> AddAsync(TEntity entity);
    ValueTask<TEntity> GetAsync(TKeyType id);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);
    IAsyncEnumerable<TEntity> AllAsync();
    IAsyncEnumerable<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChangesAsync();
}
public interface IAsyncRepository<TEntity> : IAsyncKeyTypeRepository<TEntity, Guid>;