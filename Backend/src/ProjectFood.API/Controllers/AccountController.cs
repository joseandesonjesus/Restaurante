using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectFood.API.Extensions;
using ProjectFood.Application.Dtos;
using ProjectFood.Application.Interfaces;
using ProjectFood.Domain.Identity;

namespace ProjectFood.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService,
                                 ITokenService tokenService,
                                IMapper mapper)
        {
            _accountService = accountService;
            _tokenService = tokenService;
            _mapper = mapper;

        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var userName = User.GetUserName();
                var user = await _accountService.GetUserByUserNameAsync(userName);
                return user == null ? NoContent() : Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao buscar conta, erro: {ex.Message}");
            }
        }


        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserUpdateDto userDto) // (UserDto userDto)
        {
            try
            {
                if (await _accountService.UserExists(userDto.UserName))
                {
                    return BadRequest("Usuário já existe");
                }
                if (await _accountService.CreateAccountAsync(userDto) != null)
                {
                    return Ok("Usuário cadastrado");
                }

                return BadRequest("Usuário não cadastrado, tente mais tarde!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao registrar conta, erro: {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            try
            {
                var user = await _accountService.GetUserByUserNameAsync(userLogin.UserName);

                if (user == null) return Unauthorized("Combinação de acesso inválido");

                var result = await _accountService.CheckUserPasswordAsync(user, userLogin.Password);

                if (!result.Succeeded) return Unauthorized("Combinação de acesso inválido");


                return Ok(
                    new
                    {
                        UserName = user.UserName,
                        PrimeiroNome = user.FirstName,
                        Title = user.Title,
                        Function = user.Function,
                        token = _tokenService.CreateToken(user).Result
                    }
                );


            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao realizar login, erro: {ex.Message}");
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            try
            {
                var user = await _accountService.GetUserByUserNameAsync(User.GetUserName());
                if (user == null) return Unauthorized("Usuário inválido");

                var userRet = await _accountService.UpdateAccount(userUpdateDto);
                if (userRet != null)
                {
                    return Ok(userRet);
                }

                return BadRequest("Usuário não pode ser atualizado, tente mais tarde!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao atualizar conta, erro: {ex.Message}");
            }
        }

       
        [HttpPost("RegisterTitle")]
        public async Task<IActionResult> Post(TitleDto model)
        {
            try
            {
                var title = await _accountService.CreateTitle(User.GetUserId(), model);
                if(title == null) return NoContent(); 
                return Ok(title);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro executar comando, erro: {ex.Message}");
            }
        }


    }
}