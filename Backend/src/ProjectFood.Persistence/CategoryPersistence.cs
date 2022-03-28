using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectFood.Domain;
using ProjectFood.Persistence.Contexts;
using ProjectFood.Persistence.Interfaces;

namespace ProjectFood.Persistence
{
    public class CategoryPersistence : ICategoryPersistence
    {
        public ProjectFoodContext _context { get; }

        public CategoryPersistence(ProjectFoodContext context)
        {
            _context = context;
        }

        public async Task<Category[]> GetAllCategoryAsync()
        {
            IQueryable<Category> query = _context.Category;

            // if(includeCategory){
            //     query.Include(e => e.Category)
            //     .ThenInclude(ce => ce.NameCategory);    
            // }

            // query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Category[]> GetAllCategoryByNameAsync(string Name)
        {
            IQueryable<Category> query = _context.Category;

            // if(includeCategory){
            //     query.Include(e => e.Category)
            //     .ThenInclude(ce => ce.NameCategory);    
            // }

            query = query.OrderBy(e => e.NameCategory).Where(e => e.NameCategory.ToLower().Contains(Name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int CategoryId)
        {
            IQueryable<Category> query = _context.Category;

            // if (includeCategory)
            // {
            //     query.Include(e => e.Category)
            //     .ThenInclude(ce => ce.NameCategory);
            // }

            query = query.OrderBy(e => e.Id).Where(e => e.Id == CategoryId);

            return await query.FirstOrDefaultAsync();
        }
    }
}