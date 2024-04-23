using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyShop.Infrastructure.Repositories;

public class OrderRepository(ShoppingContext context) : GenericRepository<Order>(context)
{
    public override IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
    {
        return [.. Context.Orders
            .Include(order => order.LineItems)
            .ThenInclude(lineItem => lineItem.Product)
            .Where(predicate)];
    }

    public override Order Update(Order entity)
    {
        var order = Context.Orders
            .Include(o => o.LineItems)
            .ThenInclude(lineItem => lineItem.Product)
            .Single(o => o.OrderId == entity.OrderId);

        order.OrderDate = entity.OrderDate;
        order.LineItems = entity.LineItems;

        return base.Update(order);
    }
}
