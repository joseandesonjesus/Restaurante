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
    public class OrdersTableService : IOrdersTableService
    {
        private readonly IPersistence _persistence;
        private readonly IOrdersTablePersistence _ordersTablePersistence;
        private readonly IMapper _mapper;

        public OrdersTableService(IPersistence persistence,
                                IOrdersTablePersistence ordersTablePersistence,
                                IMapper mapper
                                )
        {
            _persistence = persistence;
            _ordersTablePersistence = ordersTablePersistence;
            _mapper = mapper;
        }

        public async Task<OrdersTableDto[]> GetAllOrdersTableAsync()
        {
            try
            {
                var objects = await _ordersTablePersistence.GetAllOrdersTableAsync();
                if (objects == null) return null;

                var objectsRet = _mapper.Map<OrdersTableDto[]>(objects);

                return objectsRet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<OrdersTableDto> GetOrdersTableByIdAsync(int id)
        {
            try
            {
                var obj = await _ordersTablePersistence.GetOrdersTableByIdAsync(id);
                if (obj == null) return null;

                var objRet = _mapper.Map<OrdersTableDto>(obj);

                return objRet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<OrdersTableDto[]> GetOrdersTableByIdTableAsync(int id)
        {
            try
            {
                var obj = await _ordersTablePersistence.GetOrdersTableByIdTableAsync(id);
                if (obj == null) return null;

                var objRet = _mapper.Map<OrdersTableDto[]>(obj);

                return objRet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<OrdersTableDto> AddOrdersTable(OrdersTableDto model)
        {
            try
            {
                var obj = _mapper.Map<OrdersTable>(model);

                _persistence.Add<OrdersTable>(obj);

                if (await _persistence.SaveChangeAsync())
                {
                    var ret = await _ordersTablePersistence.GetOrdersTableByIdAsync(obj.Id);
                    return _mapper.Map<OrdersTableDto>(ret);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<OrdersTableDto> UpdateOrdersTable(OrdersTableDto model)
        {
            try
            {
                //List<OrdersTableDto> list = new List<OrdersTableDto>();
                //foreach (var item in model)
                //{
                //    var obj = await _ordersTablePersistence.GetOrdersTableByIdAsync(item.Id);
                //    //if (obj == null) continue;

                //    obj.Closed = item.Closed;

                //    //_mapper.Map(obj, item);

                //    _persistence.Update<OrdersTable>(obj);
                //    if (await _persistence.SaveChangeAsync())
                //    {
                //        var ret = await _ordersTablePersistence.GetOrdersTableByIdAsync(obj.Id);
                //        list.Add(_mapper.Map<OrdersTableDto>(ret));
                //        //return _mapper.Map<OrdersTableDto>(ret);
                //    }
                //}

                var obj = await _ordersTablePersistence.GetOrdersTableByIdAsync(model.Id);
                if (obj == null) return null;

                //model.Id = obj.Id;

                _mapper.Map(model, obj);

                _persistence.Update<OrdersTable>(obj);
                if (await _persistence.SaveChangeAsync())
                {
                    var ret = await _ordersTablePersistence.GetOrdersTableByIdAsync(obj.Id);
                    return _mapper.Map<OrdersTableDto>(ret);
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
