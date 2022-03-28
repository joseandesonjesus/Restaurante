using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectFood.Domain.Identity;
using ProjectFood.Persistence.Contexts;
using ProjectFood.Persistence.Interfaces;

namespace ProjectFood.Persistence
{
    public class UserPersist : PersistenceGeral, IUserPersist
    {
        private readonly ProjectFoodContext _context;

        public UserPersist(ProjectFoodContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            Console.WriteLine($"entra em getusername {username}");
            return await _context.Users
                                 .SingleOrDefaultAsync(user => user.UserName == username.ToLower());

        }


    }
}