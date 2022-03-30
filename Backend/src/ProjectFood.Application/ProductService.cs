using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProjectFood.Application.Dtos;
using ProjectFood.Application.Interfaces;
using ProjectFood.Domain;
using ProjectFood.Domain.Identity;
using ProjectFood.Persistence.Interfaces;

namespace ProjectFood.Application
{
    public class ProductService : IProductService
    {
        private readonly IPersistence _persistence;
        private readonly IProductPersistence _productPersistence;
        private readonly IMapper _mapper;
        private readonly IUserPersist _userPersist;
        private readonly UserManager<User> _userManager;


        public ProductService(IPersistence persistence, 
                                IProductPersistence productPersistence, 
                                IMapper mapper,
                                IUserPersist userPersist,
                                UserManager<User> userManager)
        {
            _productPersistence = productPersistence;
            _persistence = persistence;
            _mapper = mapper;
            _userPersist = userPersist;
            _userManager = userManager;

        }

        public async Task<ProductDto> AddProducts(int userId, ProductDto model)
        {
            try
            {
                var product = _mapper.Map<Product>(model);
                product.UserId = userId;
                
                _persistence.Add<Product>(product);
                
                if (await _persistence.SaveChangeAsync())
                {
                    var ret = await _productPersistence.GetProductByIdAsync(userId, product.Id, true);
                    return _mapper.Map<ProductDto>(ret);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<ProductDto> UpdateProducts(int userId, int productId, ProductDto model)
        {
            try
            {
                var product = await _productPersistence.GetProductByIdAsync(userId, productId, true);
                if (product == null) return null;

                model.Id = product.Id;

                _mapper.Map(model, product);

                _persistence.Update<Product>(product);
                if (await _persistence.SaveChangeAsync())
                {
                    var ret = await _productPersistence.GetProductByIdAsync(userId, product.Id, true);
                    return _mapper.Map<ProductDto>(ret);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
        public async Task<bool> DeleteProducts(int userId, int productId)
        {
            try
            {
                var product = await _productPersistence.GetProductByIdAsync(userId, productId, true);
                if (product == null) throw new Exception("Evento delete não encontrado");
                var productsRet = _mapper.Map<ProductDto>(product);
                _persistence.Delete<ProductDto>(productsRet);
                return await _persistence.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
        public async Task<ProductDto[]> GetAllProductsAsync(int userId, bool includeCategory = false)
        // public async Task<ProductDto[]> GetAllProductsAsync(UserUpdateDto userUpdateDto, bool includeCategory = false)
        {
            try
            {
                // var userUpdateDto = new UserUpdateDto();
                // var user = await _userPersist.GetUserByIdAsync(userId);
                //.GetUserByNameAsync(userUpdateDto.UserName);
                // Console.WriteLine(user);
                // if( user == null ){
                //     return null;
                // }
                //  _mapper.Map(userUpdateDto, user);

                // var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var products = await _productPersistence.GetAllProductsAsync(userId, includeCategory);
                if (products == null) return null;

                var productsRet = _mapper.Map<ProductDto[]>(products);

                return productsRet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<ProductDto[]> GetAllProductsByNameAsync(int userId, string nameProduct, bool includeCategory = false)
        {
            try
            {


                var products = await _productPersistence.GetAllProductsByNameAsync(userId, nameProduct, includeCategory);
                if (products == null) return null;

                var productsRet = _mapper.Map<ProductDto[]>(products);

                return productsRet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<ProductDto> GetProductByIdAsync(int userId, int ProductId, bool includeCategory = false)
        {
            try
            {
                var product = await _productPersistence.GetProductByIdAsync(userId, ProductId, includeCategory);
                if (product == null) return null;

                var productRet = _mapper.Map<ProductDto>(product);

                return productRet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }


    }
}