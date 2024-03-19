

using Domain;
using Domain.Entities;
using Infastructure.Interfaces;

namespace Infastructure.Repositories
{
    public class CategoryRepository(AppDbContext dbContext) : Repository<Category>(dbContext), ICategoryInterface
    {

    }
}
