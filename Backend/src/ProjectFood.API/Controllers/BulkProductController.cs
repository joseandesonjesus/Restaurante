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
    public class BulkProductController : ControllerBase
    {
        private readonly IBulkProductService _bulkProductService;
        private readonly IMapper _mapper;

        public BulkProductController(IBulkProductService bulkProductService,
                                    IMapper mapper)
        {
            _bulkProductService = bulkProductService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var bulks = await _bulkProductService.GetAllBulksAsync();
                if (bulks == null) return NoContent();

                var bulksReturn = new List<BulkProductDto>();

                foreach (var bulkRet in bulks)
                {
                    Console.WriteLine("categoryRet => " + bulkRet);
                    bulksReturn.Add(new BulkProductDto()
                    {
                        Id = bulkRet.Id,
                        NameBulk = bulkRet.NameBulk,
                        Abbreviation = bulkRet.Abbreviation
                    });
                }


                return Ok(bulksReturn);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var bulk = await _bulkProductService.GetBulkByIdAsync(id);
                if (bulk == null) return NoContent();
                return Ok(bulk);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(BulkProductDto model)
        {
            try
            {
                var bulk = await _bulkProductService.AddBulks(model);
                if (bulk == null) return NoContent(); //BadRequest("Não foi possivel cadastrar");
                return Ok(bulk);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscasr exento, erro: {ex.Message}");
            }
        }
    }
}
