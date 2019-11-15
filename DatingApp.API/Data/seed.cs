using System.Collections.Generic;
using System.Linq;
using DatingApp.API.Models;
using Newtonsoft.Json;

namespace DatingApp.API.Data
{
    public class seed
    {
        public static void SeedUsers(DatingContext context)
        {
            if (!context.Users.Any())
            {
                var usersData = System.IO.File.ReadAllText("Data/UsersSeedData.json");  
                var users = JsonConvert.DeserializeObject<List<Users>>(usersData);
                foreach (var user in users)
                {
                    byte[] passwordhash, passwordSalt;
                    CreatePasswordHash("password", out passwordhash, out passwordSalt);

                    user.PasswordHash = passwordhash;
                    user.PasswordSalt = passwordSalt;
                    user.UserName = user.UserName.ToLower();
                    context.Users.Add(user);
                }

                context.SaveChanges();
            }
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}

     