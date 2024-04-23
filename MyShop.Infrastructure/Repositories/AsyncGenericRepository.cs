namespace MyShop.Infrastructure.Repositories;

public abstract class AsyncGenericRepository<TEntity>(ShoppingContext context)
    : AsyncGenericGuidRepository<TEntity, ShoppingContext>(context)
    where TEntity : class
{
}
