using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectFood.Domain;
using ProjectFood.Persistence.Contexts;
using ProjectFood.Persistence.Interfaces;

namespace ProjectFood.Persistence
{
    public class PersistenceGeral : IPersistence
    {
        public ProjectFoodContext _context { get; }

        public PersistenceGeral(ProjectFoodContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityList) where T : class
        {
            _context.RemoveRange(entityList);
        }
        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }




    }
}