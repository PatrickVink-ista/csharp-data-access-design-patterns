using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace MyShop.Infrastructure;

public class AsyncUnitOfWork(ShoppingContext context) : IAsyncUnitOfWork
{
    private readonly ShoppingContext context = context;
    private IAsyncRepository<Customer> customerRepository;
    public IAsyncRepository<Customer> CustomerRepository => customerRepository ??= new AsyncCustomerRepository(context);

    private IAsyncRepository<Order> orderRepository;
    public IAsyncRepository<Order> OrderRepository => orderRepository ??= new AsyncOrderRepository(context);

    private IAsyncRepository<Product> productRepository;
    public IAsyncRepository<Product> ProductRepository => productRepository ??= new AsyncProductRepository(context);

    public Task<int> SaveChanges()
    {
        return context.SaveChanges();
    }
}
