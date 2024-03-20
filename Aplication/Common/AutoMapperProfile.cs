
using Aplication.DTOs.CategoryDTOS;
using Aplication.DTOs.ProductDTOS;
using AutoMapper;
using Domain.Entities;

namespace Aplication.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
        CreateMap<Category, CategoryDto>().ReverseMap();

        CreateMap<AddProductDto, ProductDto>();
        CreateMap<UpdateProductDto, ProductDto>();
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}


