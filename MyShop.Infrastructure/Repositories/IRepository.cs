using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyShop.Infrastructure.Repositories;

public interface IKeyTypeRepository<TEntity, TKeyType> where TKeyType : struct
{
    TEntity Add(TEntity entity);
    TEntity Get(TKeyType id);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);
    IEnumerable<TEntity> All();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    int SaveChanges();
}
public interface IRepository<TEntity> : IKeyTypeRepository<TEntity, Guid>;