using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Helpers;
using DatingApp.API.Models;

namespace DatingApp.API.Contracts
{
    public interface IDatingRepository  
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<PagedList<Users>> GetUsers(UserParams userParams);
        Task<Users> GetUser(int id);        
    }
}