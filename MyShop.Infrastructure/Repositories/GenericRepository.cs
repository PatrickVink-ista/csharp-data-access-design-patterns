namespace MyShop.Infrastructure.Repositories;

public abstract class GenericRepository<TEntity>(ShoppingContext context) 
    : GenericGuidRepository<TEntity, ShoppingContext>(context)
    where TEntity : class
{
}
