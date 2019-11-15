using DatingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Contracts
{
    public interface IBlogsRepository
    {
        Task<Blogs> Add(Blogs blog);

        IEnumerable<Blogs> GetAll(string strUserName);

        Task<Blogs> Find(int id);

        Task<Blogs> Update(Blogs blog);

        Task<Blogs> Remove(int id);

        Task<bool> Exist(int id);
    }
}
