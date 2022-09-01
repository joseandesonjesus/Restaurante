using ProjectFood.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFood.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto[]> GetAllCategoriesAsync();
        Task<CategoryDto[]> GetAllCategoriesByNameAsync(string nameCategory);
        Task<CategoryDto> GetCategoryByIdAsync(int ProductId);
        Task<CategoryDto> AddCategories(CategoryDto model);
    }
}
