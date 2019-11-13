using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlogWebSiteAPI.Contracts;
using BlogWebSiteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BlogWebSiteAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private IConfiguration _config;
        public AccountController(IUsersRepository usersRepository, IConfiguration config)
        {
            _config = config;
            _usersRepository = usersRepository;
        }

        [HttpPost]
        [Route("login")]
        // [Produces(typeof(Models.Users))]
        public async Task<IActionResult> Login([FromBody] DTO.UserForRegisterDTO userForRegister)
        {

            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState);
            // }

            var dbUser = await _usersRepository.Login(userForRegister.userName.ToLower(), userForRegister.password);

            if (dbUser != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, dbUser.UserId.ToString()),
                    new Claim(ClaimTypes.Name, dbUser.UserName),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new
                {
                    token = tokenHandler.WriteToken(token)
                });

            }
            else
                return Unauthorized();
        }


        [HttpPost]
        [Route("Register")]
        //[Produces(typeof(Models.Users))]
        public async Task<IActionResult> Register([FromBody] DTO.UserForRegisterDTO userForRegister)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }           

            bool bDuplicateaUserName = await _usersRepository.UserExists(userForRegister.userName);
            if (bDuplicateaUserName)
               return Conflict("Duplicate UserName");

            var user = new Users
            {
                UserName = userForRegister.userName,
                Email = userForRegister.email
            };

            user = await _usersRepository.Register(user, userForRegister.password);


            var results = new ObjectResult(user)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            return results;


        }
    }
}