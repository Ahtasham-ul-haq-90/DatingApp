using System.Security.Cryptography;
using System.Text;
using DatingAPP_API.Data;
using DatingAPP_API.DTO;
using DatingAPP_API.Interface;
using DatingAPP_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAPP_API.Controllers
{
  
    public class AccountController : APIController
    {
        private readonly DataContext _dbContext;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext dataContext, ITokenService tokenService)
        {
            _dbContext = dataContext;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> RegisterUser(UserRegisterDTO user)
        {
            if(await _dbContext.Users.AnyAsync(x=>x.UserName == user.UserName))
            {
                return BadRequest("UserName already Exists");
            }
            using var hmac = new HMACSHA512();
            var User = new AppUser { Email = user.Email,UserName = user.UserName.ToLower(),PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),PasswordSalt = hmac.Key };
            _dbContext.Users.Add(User);
            await _dbContext.SaveChangesAsync();
            return Ok(new UserDTO
            {
                UserName = User.UserName,
                Token = _tokenService.CreateToken(User)
            });
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO login) {
            var User = await _dbContext.Users.SingleOrDefaultAsync(x => x.UserName.ToLower() == login.UserName.ToLower());
            if (User == null) { 
            return Unauthorized("Invalid username");
            }
            using var hmac = new HMACSHA512(User.PasswordSalt);
            var ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));
            for(int i = 0; i < ComputedHash.Length; i++)
            {
                if (User.PasswordHash[i] != ComputedHash[i]) {
                    return Unauthorized("Invalid password");
                }
            }
            return Ok(new UserDTO
            {
                UserName = User.UserName,
                Token = _tokenService.CreateToken(User)
            });
        }

    }
}
