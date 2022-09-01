using ProjectFood.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFood.Application.Interfaces
{
    public interface IOrdersTableService
    {
        Task<OrdersTableDto[]> GetAllOrdersTableAsync();
        Task<OrdersTableDto> GetOrdersTableByIdAsync(int id);
        Task<OrdersTableDto[]> GetOrdersTableByIdTableAsync(int id);
        Task<OrdersTableDto> UpdateOrdersTable(OrdersTableDto model);
        Task<OrdersTableDto> AddOrdersTable(OrdersTableDto model);
    }
}
