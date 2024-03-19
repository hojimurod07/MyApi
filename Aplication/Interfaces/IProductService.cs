
using Aplication.DTOs.ProductDTOS;

namespace Aplication.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task AddAsync(AddProductDto productDto);
        Task UpdateAsync(UpdateProductDto productDto);
        Task DeleteAsync(int id);

    }
}
