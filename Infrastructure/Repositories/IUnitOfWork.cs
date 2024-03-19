using Infastructure.Interfaces;
using Infrastructure;

namespace Infastructure.Repositories
{
    public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
    {
        private readonly AppDbContext _dbContext = dbContext;


        public ICategoryInterface Categoryies => new CategoryRepository(_dbContext);

        public IProductInterface Products => new ProductRepository(_dbContext);


    }
}
