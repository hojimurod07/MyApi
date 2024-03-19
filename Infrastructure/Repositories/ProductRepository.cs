
using Domain;
using Domain.Entities;
using Infastructure.Interfaces;

namespace Infastructure.Repositories
{
    public class ProductRepository(AppDbContext dbContext) : Repository<Product>(dbContext), IProductInterface
    {
    }
}
