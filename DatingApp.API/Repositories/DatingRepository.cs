using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Contracts;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Repositories
{
    public class DatingRepository : IDatingRepository
    {
        private DatingContext _context;
        public DatingRepository(DatingContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
           _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }

        public async Task<Users> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.UserId == id);
            return user;
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
           var user = await _context.Users.Include(p => p.Photos).ToListAsync();
            return user;
        }

        public async Task<bool> SaveAll()
        {
           return await _context.SaveChangesAsync() > 0;
        }
    }
}