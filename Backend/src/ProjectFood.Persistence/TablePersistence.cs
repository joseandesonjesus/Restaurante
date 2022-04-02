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
    public class TablePersistence : ITablePersistence
    {
        public ProjectFoodContext _context { get; }

        public TablePersistence(ProjectFoodContext context)
        {
            _context = context;
        }

        public async Task<InTable[]> GetAllTablesAsync()
        {
            IQueryable<InTable> query = _context.Tables;

            // if(includeCategory){
            //     query.Include(e => e.Category)
            //     .ThenInclude(ce => ce.NameCategory);    
            // }

            // query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<InTable> GetTableByIdAsync(int TableId)
        {
            IQueryable<InTable> query = _context.Tables;

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
