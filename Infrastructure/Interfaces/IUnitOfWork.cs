

namespace Infastructure.Interfaces;

public interface IUnitOfWork
{

    ICategoryInterface Categoryies { get; }
    IProductInterface Products { get; }


}
