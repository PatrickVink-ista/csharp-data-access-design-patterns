using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace MyShop.Infrastructure;

public interface IAsyncUnitOfWork
{
    IAsyncRepository<Customer> CustomerRepository { get; }
    IAsyncRepository<Order> OrderRepository { get; }
    IAsyncRepository<Product> ProductRepository { get; }

    Task<int> SaveChanges();
}
