using Microsoft.EntityFrameworkCore;
using ProjectFood.Domain;
using ProjectFood.Persistence.Contexts;
using ProjectFood.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFood.Persistence
{
    public class BulkProductPersistence : IBulkProductPersistence
    {
        public ProjectFoodContext _context { get; }

        public BulkProductPersistence(ProjectFoodContext context)
        {
            _context = context;
        }

        public async Task<BulkProduct[]> GetAllBulksAsync()
        {
            IQueryable<BulkProduct> query = _context.Bulks;

            // if(includeCategory){
            //     query.Include(e => e.Category)
            //     .ThenInclude(ce => ce.NameCategory);    
            // }

            // query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<BulkProduct> GetBulkByIdAsync(int TableId)
        {
            IQueryable<BulkProduct> query = _context.Bulks;

            // if (includeCategory)
            // {
            //     query.Include(e => e.Category)
            //     .ThenInclude(ce => ce.NameCategory);
            // }

            query = query.OrderBy(e => e.Id).Where(e => e.Id == TableId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
