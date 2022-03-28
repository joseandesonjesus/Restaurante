using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ProjectFood.Persistence.Contexts;

namespace ProjectFood.API.Data
{
    public class DbInitializer
    {
        private readonly ProjectFoodContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _environment;
        
        public DbInitializer(ProjectFoodContext context, IConfiguration configuration, IHostEnvironment environment)
        {
            _context = context;
            _configuration = configuration;
            _environment = environment;
        }
        
        public async Task Run()
        {
            await _context.Database.MigrateAsync();
        }
    }
}