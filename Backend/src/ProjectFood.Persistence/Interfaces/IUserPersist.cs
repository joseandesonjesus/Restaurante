using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectFood.Domain.Identity;

namespace ProjectFood.Persistence.Interfaces
{
    public interface IUserPersist : IPersistence
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByNameAsync(string userName);
        
    }
}