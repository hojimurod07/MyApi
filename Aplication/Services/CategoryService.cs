
using Aplication.Common;
using Aplication.DTOs.CategoryDTOS;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infastructure.Interfaces;

namespace Aplication.Services
{
    public class CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<Category> validator) : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<Category> _validator = validator;

        public async Task AddAsync(AddCategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                throw new CustomException("Model bosh bolmasligi kerak");
            }
            var model = _mapper.Map<Category>(categoryDto);
            var result = await _validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                throw new CustomException(string.Join("\n", result.Errors.Select(x => x.ErrorMessage)));
            }
            await _unitOfWork.Categoryies.AddAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _unitOfWork.Categoryies.GetByIdAsync(id);
            if (model == null)
            {
                throw new NotFoundException("Categoriya topilmadi");
            }

        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var cateegories = await _unitOfWork.Categoryies.GetAllAsync();
            var result = cateegories.Select(_mapper.Map<CategoryDto>).ToList();
            return result;
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var model = await _unitOfWork.Categoryies.GetByIdAsync(id);
            if (model == null)
            {
                throw new NotFoundException("Categoriya topilmadi");
            }
            return _mapper.Map<CategoryDto>(model);
        }

        public async Task UpdateAsync(UpdateCategoryDto categoryDto)
        {
            var model = await _unitOfWork.Categoryies.GetByIdAsync(categoryDto.Id);
            if (model == null)
            {
                throw new NotFoundException("Categoriya topilmadi");
            }
            model.Name = categoryDto.Name;
            var result = await _validator.ValidateAsync(model);
            if (!result.IsValid)

            {
                throw new CustomException(string.Join("\n", result.Errors.Select(x => x.ErrorMessage)));
            }
            await _unitOfWork.Categoryies.UpdateAsync(model);


        }
    }
}
