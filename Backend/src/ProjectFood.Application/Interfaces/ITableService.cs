using ProjectFood.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFood.Application.Interfaces
{
    public interface ITableService
    {
        Task<InTableDto> AddTables(InTableDto model);
        Task<InTableDto> UpdateTable(InTableDto model);
        Task<InTableDto[]> GetAllTablesAsync();
        Task<InTableDto> GetTableByIdAsync(int id);
    }
}
