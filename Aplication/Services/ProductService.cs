

using Aplication.Common;
using Aplication.DTOs.ProductDTOS;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infastructure.Interfaces;

namespace Aplication.Services
{
    public class ProductService(IMapper mapper, IValidator<Product> validator, IUnitOfWork unitOfWork) : IProductService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<Product> _validator = validator;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task AddAsync(AddProductDto productDto)
        {
            if (productDto == null)
            {
                throw new CustomException("Model bosh bolmasligi kerak");
            }
            var model = _mapper.Map<Product>(productDto);
            var result = await _validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                throw new CustomException(string.Join("\n", result.Errors.Select(x => x.ErrorMessage)));
            }
            await _unitOfWork.Products.AddAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _unitOfWork.Products.GetByIdAsync(id);
            if (model == null)
            {
                throw new NotFoundException("Product topilmadi");
            }

        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var vv = await _unitOfWork.Products.GetAllAsync();
            var result = vv.Select(_mapper.Map<ProductDto>).ToList();
            return result;
        }
        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var model = await _unitOfWork.Products.GetByIdAsync(id);
            if (model == null)
            {
                throw new NotFoundException("PRoduct topilmadi");
            }
            return _mapper.Map<ProductDto>(model);

        }

        public async Task UpdateAsync(UpdateProductDto productDto)
        {
            var model = await _unitOfWork.Products.GetByIdAsync(productDto.Id);
            if (model == null)
            {
                throw new NotFoundException("Product topilmadi");
            }
            model.Name = productDto.Name;
            model.Description = productDto.Description;
            model.Price = productDto.Price;
            model.CategoryId = productDto.CategoryId;
            var result = await _validator.ValidateAsync(model);
            if (!result.IsValid)

            {
                throw new CustomException(string.Join("\n", result.Errors.Select(x => x.ErrorMessage)));
            }
            await _unitOfWork.Products.UpdateAsync(model);

        }

    }

}
