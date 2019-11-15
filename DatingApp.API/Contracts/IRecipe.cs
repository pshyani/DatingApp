using DatingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Contracts
{
    interface IRecipe
    {
        Task<Recipe> Add(Recipe recipe);

        IEnumerable<Recipe> GetAll(string strUserName);

        Task<Recipe> Find(int id);

        Task<Recipe> Update(Recipe recipe);

        Task<Recipe> Remove(int id);

        Task<bool> Exist(int id);
    }
}
