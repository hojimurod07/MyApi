using Aplication.Common;
using Aplication.DTOs.CategoryDTOS;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var res = await _categoryService.GetByIdAsync(id);
                return Ok(res);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddCategoryDto dto)
        {
            try
            {
                await _categoryService.AddAsync(dto);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (CustomException e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateCategoryDto dto)
        {
            try
            {
                await _categoryService.UpdateAsync(dto);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (CustomException e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
