
using Shop.Domain.Entities;
using Shop.Infrastructure.Repositories;

namespace Shop.Application.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
}