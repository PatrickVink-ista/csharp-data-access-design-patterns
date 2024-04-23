using MyShop.Domain.Models;
using System.Linq;

namespace MyShop.Infrastructure.Repositories;

public class ProductRepository(ShoppingContext context) : GenericRepository<Product>(context)
{
    public override Product Update(Product entity)
    {
        var product = Context.Products
            .Single(p => p.ProductId == entity.ProductId);

        product.Price = entity.Price;
        product.Name = entity.Name;

        return base.Update(product);
    }
}
