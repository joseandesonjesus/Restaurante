using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectFood.Application.Dtos;

namespace ProjectFood.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDto userUpdateDto);
    }
}