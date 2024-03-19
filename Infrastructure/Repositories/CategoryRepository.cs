using Domain.Entities;
using Infastructure.Interfaces;
using Infrastructure;

namespace Infastructure.Repositories
{
    public class CategoryRepository(AppDbContext dbContext) : Repository<Category>(dbContext), ICategoryInterface
    {

    }
}
