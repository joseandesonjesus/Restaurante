using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        private readonly IMapper _mapper;

        public TableController(ITableService tableService,
                                    IMapper mapper)
        {
            _tableService = tableService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tables = await _tableService.GetAllTablesAsync();
                if (tables == null) return NoContent();

                var tablesReturn = new List<InTableDto>();

                foreach (var tableRet in tables)
                {
                    tablesReturn.Add(new InTableDto()
                    {
                        Id = tableRet.Id,
                        StatusTable = tableRet.StatusTable
                    });
                }


                return Ok(tablesReturn);
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
                var obj = await _tableService.GetTableByIdAsync(id);
                if (obj == null) return NoContent();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(InTableDto model)
        {
            try
            {
                var table = await _tableService.AddTables(model);
                if (table == null) return NoContent(); //BadRequest("Não foi possivel cadastrar");
                return Ok(table);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(InTableDto model)
        {
            try
            {
                var obj = await _tableService.UpdateTable(model);
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
