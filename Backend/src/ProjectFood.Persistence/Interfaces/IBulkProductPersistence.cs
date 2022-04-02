using ProjectFood.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFood.Persistence.Interfaces
{
    public interface IBulkProductPersistence
    {
        Task<BulkProduct[]> GetAllBulksAsync();
        Task<BulkProduct> GetBulkByIdAsync(int TableId);
    }
}
