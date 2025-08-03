using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DatingAPP_API.Interface;
using Microsoft.IdentityModel.Tokens;

namespace DatingAPP_API.Service
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration configuration) {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }
        public string CreateToken(AppUser user)
        {
            var Claims = new List<Claim>
               {
                   new Claim(JwtRegisteredClaimNames.NameId,user.UserName)

               };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.Aes256CbcHmacSha512);
            var TokenDiscripter = new SecurityTokenDescriptor { 
                Subject =new ClaimsIdentity(Claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };
            var TokenHandler = new JwtSecurityTokenHandler();
            var Token = TokenHandler.CreateToken(TokenDiscripter);
            return TokenHandler.WriteToken(Token);
        }
    }
}
