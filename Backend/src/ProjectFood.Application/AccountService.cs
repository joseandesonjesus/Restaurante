using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectFood.Application.Dtos;
using ProjectFood.Application.Interfaces;
using ProjectFood.Domain.Identity;
using ProjectFood.Persistence.Interfaces;

namespace ProjectFood.Application
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserPersist _userPersist;

        public AccountService(UserManager<User> userManager,
                                SignInManager<User> signInManager,
                                IMapper mapper,
                                IUserPersist userPersist
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userPersist = userPersist;
        }
        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto userUpdateDto, string password)
        {
            try
            {
                var user = await _userManager.Users
                                            .SingleOrDefaultAsync(user => user.UserName == userUpdateDto.UserName.ToLower());

               

                return await _signInManager.CheckPasswordSignInAsync(user, password, false);
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao verificar password. Erro:  {ex.Message}");
            }
        }

        public async Task<UserDto> CreateAccountAsync(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                
                var result = await _userManager.CreateAsync(user, userDto.Password);

                return 
                result.Succeeded 
                ? _mapper.Map<UserDto>(user)
                : null;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao criar conta. Erro:  {ex.Message}");
            }
        }

        public async Task<UserUpdateDto> GetUserByUserNameAsync(string userName)
        {
            try
            {
                var user = await _userPersist.GetUserByNameAsync(userName);
                return user == null 
                            ? null
                            : _mapper.Map<UserUpdateDto>(user);
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao encontrar por username. Erro:  {ex.Message}");
            }
        }

        public async Task<UserUpdateDto> UpdateAccount(UserUpdateDto userUpdateDto)
        {
            try
            {
                var user = await _userPersist.GetUserByNameAsync(userUpdateDto.UserName);
                if( user == null ){
                    return null;
                }
                
                _mapper.Map(userUpdateDto, user);

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, userUpdateDto.Password);

                _userPersist.Update<User>(user);

                if(await _userPersist.SaveChangeAsync()){
                    var userReturn = await _userPersist.GetUserByNameAsync(user.UserName);
                    return _mapper.Map<UserUpdateDto>(userReturn);
                }
                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao atualizar conta. Erro:  {ex.Message}");
            }
        }

        public async Task<bool> UserExists(string userName)
        {
            try
            {
               
                return await _userManager.Users
                                         .AnyAsync(user => user.UserName == userName.ToLower());
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao verificar se usuário existe. Erro:  {ex.Message}");
            }
        }
    }
}