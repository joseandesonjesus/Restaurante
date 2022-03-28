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
    public class ProductPersistence : IProductPersistence
    {
        public ProjectFoodContext _context { get; }

        public ProductPersistence(ProjectFoodContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Product[]> GetAllProductsAsync(int userId, bool includeCategory = false)
        {
            IQueryable<Product> query = _context.Products
                                                .Include(e => e.Image);
                                        // .Include(e => e.Category);

            if(includeCategory){
                query = query.Include(e => e.Category)
            //                  .ThenInclude(ce => ce.NameCategory)
            ;
            }
            
            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Product[]> GetAllProductsByNameAsync(int userId, string nameProduct, bool includeCategory = false)
        {
            IQueryable<Product> query = _context.Products
                                                .Include(e => e.Image);

            if(includeCategory){
               query = query.Include(e => e.Category)
                // .ThenInclude(ce => ce.NameCategory);  
                ;  
            }
            
            query = query.OrderBy(e => e.Id).Where(e => e.NameProduct.ToLower().Contains(nameProduct.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Product> GetProductByIdAsync(int userId, int ProductId, bool includeCategory = false)
        {
            IQueryable<Product> query = _context.Products
                                                .Include(e => e.Image);

            if(includeCategory){
                query = query.Include(e => e.Category)
                // .ThenInclude(ce => ce.NameCategory)
                ;  
            }
            
            query = query.OrderBy(e => e.Id).Where(e => e.Id == ProductId);

            return await query.FirstOrDefaultAsync();
        }


    }
}