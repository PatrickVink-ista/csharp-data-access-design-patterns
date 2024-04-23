using MyShop.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Infrastructure.Repositories;

public class ProductRepository(ShoppingContext context) : GenericRepository<Product>(context)
{
    public override IEnumerable<Product> All()
    {
        return base.All().OrderBy(x => x.Name);
    }
    public override Product Update(Product entity)
    {
        var product = Context.Products
            .Single(p => p.ProductId == entity.ProductId);

        product.Price = entity.Price;
        product.Name = entity.Name;

        return base.Update(product);
    }
}
