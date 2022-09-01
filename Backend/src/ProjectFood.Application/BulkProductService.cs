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
    public class BulkProductService : IBulkProductService
    {
        private readonly IPersistence _persistence;
        private readonly IBulkProductPersistence _bulkProductPersistence;

        private readonly IMapper _mapper;

        public BulkProductService(IPersistence persistence,
                                IBulkProductPersistence bulkProductPersistence,
                                IMapper mapper)
        {
            _bulkProductPersistence = bulkProductPersistence;
            _persistence = persistence;
            _mapper = mapper;

        }

        public async Task<BulkProductDto[]> GetAllBulksAsync()
        {
            try
            {
                var bulks = await _bulkProductPersistence.GetAllBulksAsync();
                if (bulks == null) return null;

                var bulksRet = _mapper.Map<BulkProductDto[]>(bulks);

                return bulksRet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<BulkProductDto> GetBulkByIdAsync(int id)
        {
            try
            {
                var bulk = await _bulkProductPersistence.GetBulkByIdAsync(id);
                if (bulk == null) return null;

                var bulkRet = _mapper.Map<BulkProductDto>(bulk);

                return bulkRet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<BulkProductDto> AddBulks(BulkProductDto model)
        {
            try
            {
                var bulk = _mapper.Map<BulkProduct>(model);

                _persistence.Add<BulkProduct>(bulk);

                if (await _persistence.SaveChangeAsync())
                {
                    var ret = await _bulkProductPersistence.GetBulkByIdAsync(bulk.Id);
                    return _mapper.Map<BulkProductDto>(ret);
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
