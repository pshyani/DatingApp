using DatingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Contracts
{
    public interface IUsersRepository
    {
        Task<Users> Register(Users user, string password);

        Task<Users> Login(string userName, string password);

        Task<bool> UserExists(string userName);
                                   

        //IEnumerable<Users> GetAll();

        //Task<Users> Find(string userName, string password);

        //bool FindDuplicateEmail(string Email);

        //bool FindDuplicateUserName(string userName);

        //Task<Users> Update(Users user);

        //Task<Users> Remove(int id);

        //Task<bool> Exist(int id);
    }
}
