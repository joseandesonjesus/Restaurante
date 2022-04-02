using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectFood.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using ProjectFood.Application.Dtos;
using AutoMapper;
using ProjectFood.API.Extensions;
using ProjectFood.Application;
using Microsoft.AspNetCore.Authorization;
using ProjectFood.Domain.Identity;


namespace ProjectFood.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public ProductController(IProductService productService,
            ICategoryService categoryService,
            IMapper mapper,
        IAccountService accountService ){
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
            _accountService = accountService;
        }


       
        [HttpGet]
        // public Product Get()
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync(User.GetUserId(),true);
                //GetAllProductsAsync(User,true);
                // var products = await _productService.GetAllProductsAsync(User.GetUserId(),true);
                
                if(products == null) return NoContent();

                var productsReturn = new List<ProductDto>();
                
                foreach (var productRet in products)
                {
                    var categories = await _categoryService.GetCategoryByIdAsync(productRet.CategoryId);
                    Console.WriteLine("productRet => " + productRet);
                    productsReturn.Add(new ProductDto(){
                        Id = productRet.Id,
                        Image = productRet.Image,
                        NameProduct = productRet.NameProduct,
                        PriceProduct = productRet.PriceProduct,
                        Discount = productRet.Discount,
                        DateRegister = productRet.DateRegister,
                        StatusProduct = productRet.StatusProduct,
                        Category = categories
                    });
                }


                return Ok(productsReturn);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
                //throw new Exception("Error: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(User.GetUserId(), id, true);
                if(product == null) return NoContent();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
            }
        }

        [HttpGet("title/{title}")]
        public async Task<IActionResult> Get(string nameProduct)
        {
            try
            {
                var product = await _productService.GetAllProductsByNameAsync(User.GetUserId(), nameProduct, true);
                if (product == null) return NoContent();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDto model)
        {
            try
            {
                var product = await _productService.AddProducts( User.GetUserId(),model);
                if(product == null) return NoContent(); //BadRequest("Não foi possivel cadastrar");
                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductDto model)
        {
           try
            {
                var product = await _productService.UpdateProducts(User.GetUserId(), id, model);
                if(product == null) return BadRequest("Não foi possivel atualizar");
                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao adicionar produto, erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(User.GetUserId(), id, true);
                if(product == null) return NoContent();

                var productDelete = await _productService.DeleteProducts(User.GetUserId(), id);

                //if (productDelete)
                //{
                //    return Ok("Deletado");
                //}
                //else
                //{
                //    return BadRequest("Não foi possivel apagar");
                //}
                return await _productService.DeleteProducts(User.GetUserId(), id)
                            ? Ok("Deletado")
                            : BadRequest("Não foi possivel apagar");


            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao deletar produto, erro: {ex.Message}");
            }
        }
    }
}
