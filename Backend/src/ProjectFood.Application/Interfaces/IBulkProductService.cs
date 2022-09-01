using ProjectFood.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFood.Application.Interfaces
{
    public interface IBulkProductService
    {
        Task<BulkProductDto> AddBulks(BulkProductDto model);
        Task<BulkProductDto> GetBulkByIdAsync(int BulkId);
        Task<BulkProductDto[]> GetAllBulksAsync();
    }
}
