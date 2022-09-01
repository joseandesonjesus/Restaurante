using ProjectFood.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFood.Persistence.Interfaces
{
    public interface IOrdersTablePersistence
    {
        Task<OrdersTable[]> GetAllOrdersTableAsync();
        Task<OrdersTable> GetOrdersTableByIdAsync(int id);
        Task<OrdersTable[]> GetOrdersTableByIdTableAsync(int id);
    }
}
