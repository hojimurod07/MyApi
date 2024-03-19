

using Aplication.DTOs.CategoryDTOS;

namespace Aplication.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task AddAsync(AddCategoryDto categoryDto);
        Task UpdateAsync(UpdateCategoryDto categoryDto);
        Task DeleteAsync(int id);
    }
}
