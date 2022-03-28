using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectFood.Domain;

namespace ProjectFood.Persistence.Interfaces
{
    public interface ICategoryPersistence
    {
        Task<Category[]> GetAllCategoryByNameAsync(string Name);
        Task<Category[]> GetAllCategoryAsync();
        Task<Category> GetCategoryByIdAsync(int CategoryId);
    }
}