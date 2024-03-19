using Domain.Entities;
using Infastructure.Interfaces;
using Infrastructure;

namespace Infastructure.Repositories
{
    public class ProductRepository(AppDbContext dbContext) : Repository<Product>(dbContext), IProductInterface
    {
    }
}
