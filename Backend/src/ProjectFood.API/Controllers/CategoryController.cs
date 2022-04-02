using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectFood.Application.Dtos;
using ProjectFood.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFood.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, 
                                    IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                if (categories == null) return NoContent();

                var categoriesReturn = new List<CategoryDto>();

                foreach (var categoryRet in categories)
                {
                    Console.WriteLine("categoryRet => " + categoryRet);
                    categoriesReturn.Add(new CategoryDto()
                    {
                        Id = categoryRet.Id,
                        NameCategory = categoryRet.NameCategory,
                        BulkProduct = categoryRet.BulkProduct,
                        //ProductId = categoryRet.ProductId
                    });
                }


                return Ok(categoriesReturn);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                if (category == null) return NoContent();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryDto model)
        {
            try
            {
                var product = await _categoryService.AddCategories(model);
                if (product == null) return NoContent(); //BadRequest("Não foi possivel cadastrar");
                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
            }
        }
    }
}
