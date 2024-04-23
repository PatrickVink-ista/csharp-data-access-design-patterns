using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Infrastructure;

public interface IUnitOfWork
{
    IRepository<Customer> CustomerRepository { get; }
    IRepository<Order> OrderRepository { get; }
    IRepository<Product> ProductRepository { get; }

    int SaveChanges();
}

public class UnitOfWork(ShoppingContext context) : IUnitOfWork
{
    private readonly ShoppingContext context = context;
    private IRepository<Customer> customerRepository;
    public IRepository<Customer> CustomerRepository => customerRepository ??= new CustomerRepository(context);

    private IRepository<Order> orderRepository;
    public IRepository<Order> OrderRepository => orderRepository ??= new OrderRepository(context);

    private IRepository<Product> productRepository;
    public IRepository<Product> ProductRepository => productRepository ??= new ProductRepository(context);

    public int SaveChanges()
    {
        return context.SaveChanges();
    }
}
