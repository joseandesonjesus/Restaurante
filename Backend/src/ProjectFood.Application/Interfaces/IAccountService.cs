using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProjectFood.Application.Dtos;

namespace ProjectFood.Application.Interfaces
{
    public interface IAccountService
    {
        Task<bool> UserExists(string username);
        Task<UserUpdateDto> GetUserByUserNameAsync(string username);
        Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto userUpdateDto, string password);

        Task<UserDto> CreateAccountAsync(UserDto userDto);
        Task<UserUpdateDto> UpdateAccount(UserUpdateDto userUpdateDto);
    
        Task<TitleDto> CreateTitle(int userId, TitleDto titleDto);
        Task<TitleDto> UpdateTitle(TitleDto titleDto);
        Task<FunctionDto> CreateFunction(FunctionDto functionDto);
        Task<FunctionDto> UpdateFunction(FunctionDto functionDto);
    }
}