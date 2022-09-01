using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectFood.API.Extensions;
using ProjectFood.Application.Dtos;
using ProjectFood.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFood.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersTableController : ControllerBase
    {
        private readonly IOrdersTableService _ordersTableService;
        private readonly IProductService _productService;
        private readonly ITableService _tableService;
        private readonly IMapper _mapper;

        public OrdersTableController(IOrdersTableService ordersTableService,
                                    IProductService productService,
                                    ITableService tableService,
                                    IMapper mapper)
        {
            _ordersTableService = ordersTableService;
            _tableService = tableService;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var objects = await _ordersTableService.GetAllOrdersTableAsync();
                if (objects == null) return NoContent();

                var objectsReturn = new List<OrdersTableDto>();

                foreach (var objectRet in objects)
                {
                    var table = await _tableService.GetTableByIdAsync(objectRet.InTableId);
                    var product = await _productService.GetProductByIdAsync(User.GetUserId(), objectRet.ProductId, true);
                    Console.WriteLine("Ret => " + objectRet);
                    objectsReturn.Add(new OrdersTableDto()
                    {
                        Id = objectRet.Id,
                        InTableId = objectRet.InTableId,
                        InTable = table,
                        ProductId = objectRet.ProductId,
                        Product = product,
                        Amount = objectRet.Amount,
                        Obs = objectRet.Obs,
                        Opened = objectRet.Opened,
                        Closed = objectRet.Closed
                    });
                }


                return Ok(objectsReturn);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
            }
        }

        [HttpGet("ById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                //var obj = await _ordersTableService.GetOrdersTableByIdAsync(id);
                //if (obj == null) return NoContent();
                //return Ok(obj);

                var objectRet = await _ordersTableService.GetOrdersTableByIdAsync(id);
                if (objectRet == null) return NoContent();

                var objectsReturn = new List<OrdersTableDto>();

                var table = await _tableService.GetTableByIdAsync(objectRet.InTableId);
                var product = await _productService.GetProductByIdAsync(User.GetUserId(), objectRet.ProductId, true);
                Console.WriteLine("Ret => " + objectRet);
                objectsReturn.Add(new OrdersTableDto()
                {
                    Id = objectRet.Id,
                    InTableId = objectRet.InTableId,
                    InTable = table,
                    ProductId = objectRet.ProductId,
                    Product = product,
                    Amount = objectRet.Amount,
                    Obs = objectRet.Obs,
                    Opened = objectRet.Opened,
                    Closed = objectRet.Closed
                });

                return Ok(objectsReturn);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
            }
        }

        [HttpGet("ByIdTable/{id}")]
        public async Task<IActionResult> GetByIdTable(int id)
        {
            try
            {
                //var obj = await _ordersTableService.GetOrdersTableByIdTableAsync(id);
                //if (obj == null) return NoContent();
                //return Ok(obj);

                var objects = await _ordersTableService.GetOrdersTableByIdTableAsync(id);
                if (objects == null) return NoContent();

                var objectsReturn = new List<OrdersTableDto>();

                foreach (var objectRet in objects)
                {
                    var table = await _tableService.GetTableByIdAsync(objectRet.InTableId);
                    var product = await _productService.GetProductByIdAsync(User.GetUserId(), objectRet.ProductId, true);
                    Console.WriteLine("Ret => " + objectRet);
                    objectsReturn.Add(new OrdersTableDto()
                    {
                        Id = objectRet.Id,
                        InTableId = objectRet.InTableId,
                        InTable = table,
                        ProductId = objectRet.ProductId,
                        Product = product,
                        Amount = objectRet.Amount,
                        Obs = objectRet.Obs,
                        Opened = objectRet.Opened,
                        Closed = objectRet.Closed
                    });
                }


                return Ok(objectsReturn);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrdersTableDto model)
        {
            try
            {
                var obj = await _ordersTableService.AddOrdersTable(model);
                if (obj == null) return NoContent(); //BadRequest("Não foi possivel cadastrar");
                var objTable = await _tableService.GetTableByIdAsync(model.InTableId);
                objTable.StatusTable = false;
                await _tableService.UpdateTable(objTable);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(OrdersTableDto model)
        {
            try
            {
                model.InTable.StatusTable = true;
                var obj = await _ordersTableService.UpdateOrdersTable(model);
                if (obj == null) return BadRequest("Não foi possivel atualizar");
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao adicionar produto, erro: {ex.Message}");
            }
        }
    }
}
