using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectFood.Domain;

namespace ProjectFood.Persistence.Interfaces
{
    public interface IProductPersistence
    {
      
        Task<Product[]> GetAllProductsByNameAsync(int userId, string nameProduct, bool includeCategory);
        Task<Product[]> GetAllProductsAsync(int userId, bool includeCategory);
        Task<Product> GetProductByIdAsync(int userId, int ProductId, bool includeCategory);
        Task<Product[]> GetProductByIdCategoryAsync(int userId, int CategoryId, bool includeCategory);
    }
}