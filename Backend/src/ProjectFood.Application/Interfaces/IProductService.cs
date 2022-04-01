using System.Threading.Tasks;
using ProjectFood.Application.Dtos;
using ProjectFood.Domain.Identity;

namespace ProjectFood.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> AddProducts(int userId, ProductDto model);
        Task<ProductDto> UpdateProducts(int userId, int productId, ProductDto model);
        Task<bool> DeleteProducts(int userId, int productId);

        
        Task<ProductDto[]> GetAllProductsByNameAsync(int userId, string nameProduct, bool includeCategory);
        Task<ProductDto[]> GetAllProductsAsync(int userId, bool includeCategory);
        // Task<ProductDto[]> GetAllProductsAsync(User user, bool includeCategory);
        
        Task<ProductDto> GetProductByIdAsync(int userId, int ProductId, bool includeCategory);

    }
}