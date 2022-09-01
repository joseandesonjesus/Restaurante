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
    public class OrdersTablePersistence : IOrdersTablePersistence
    {
        public ProjectFoodContext _context { get; }

        public OrdersTablePersistence(ProjectFoodContext context)
        {
            _context = context;
        }

        public async Task<OrdersTable[]> GetAllOrdersTableAsync()
        {
            IQueryable<OrdersTable> query = _context.OrdersTables;

            return await query.ToArrayAsync();
        }

        public async Task<OrdersTable> GetOrdersTableByIdAsync(int id)
        {
            IQueryable<OrdersTable> query = _context.OrdersTables;

            query = query.Include(e => e.InTable);

            query = query.Include(e => e.Product);

            query = query.OrderBy(e => e.Id).Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<OrdersTable[]> GetOrdersTableByIdTableAsync(int id)
        {
            IQueryable<OrdersTable> query = _context.OrdersTables;

            query = query.Include(e => e.InTable);

            query = query.Include(e => e.Product);

            query = query.OrderBy(e => e.Id).Where(e => e.InTableId == id).Where(c => c.Closed == null);

            return await query.ToArrayAsync();
        }
    }
}
