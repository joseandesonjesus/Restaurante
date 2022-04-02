using ProjectFood.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFood.Persistence.Interfaces
{
    public interface ITablePersistence
    {
        Task<InTable[]> GetAllTablesAsync();
        Task<InTable> GetTableByIdAsync(int TableId);
    }
}
