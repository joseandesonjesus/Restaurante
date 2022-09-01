using AutoMapper;
using ProjectFood.Application.Dtos;
using ProjectFood.Application.Interfaces;
using ProjectFood.Domain;
using ProjectFood.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFood.Application
{
    public class TableService : ITableService
    {
        private readonly IPersistence _persistence;
        private readonly ITablePersistence _tablePersistence;

        private readonly IMapper _mapper;

        public TableService(IPersistence persistence,
                                ITablePersistence tablePersistence,
                                IMapper mapper)
        {
            _tablePersistence = tablePersistence;
            _persistence = persistence;
            _mapper = mapper;

        }

        public async Task<InTableDto[]> GetAllTablesAsync()
        {
            try
            {
                var tables = await _tablePersistence.GetAllTablesAsync();
                if (tables == null) return null;

                var tablesRet = _mapper.Map<InTableDto[]>(tables);

                return tablesRet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<InTableDto> GetTableByIdAsync(int id)
        {
            try
            {
                var obj = await _tablePersistence.GetTableByIdAsync(id);
                if (obj == null) return null;

                var objRet = _mapper.Map<InTableDto>(obj);

                return objRet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<InTableDto> AddTables(InTableDto model)
        {
            try
            {
                var table = _mapper.Map<InTable>(model);

                _persistence.Add<InTable>(table);

                if (await _persistence.SaveChangeAsync())
                {
                    var ret = await _tablePersistence.GetTableByIdAsync(table.Id);
                    return _mapper.Map<InTableDto>(ret);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<InTableDto> UpdateTable(InTableDto model)
        {
            try
            {
                var obj = await _tablePersistence.GetTableByIdAsync(model.Id);
                if (obj == null) return null;

                //model.Id = obj.Id;

                _mapper.Map(model, obj);

                _persistence.Update<InTable>(obj);
                if (await _persistence.SaveChangeAsync())
                {
                    var ret = await _tablePersistence.GetTableByIdAsync(obj.Id);
                    return _mapper.Map<InTableDto>(ret);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
