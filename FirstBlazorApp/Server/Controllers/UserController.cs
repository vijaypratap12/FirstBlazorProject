using FirstBlazorApp.Server.DAL.Interfaces;
using FirstBlazorApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FirstBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepo _userRepo;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost, Route("Login")]
        [AllowAnonymous]
        public IActionResult LoginUser(User user)
        {
            var users = _userRepo.GetUserDetail(user);
            //if (user.UserName == "joydip" && user.Password == "joydip123")
            if(users!=null)
            {
                var issuer = _configuration.GetValue<string>("Jwt:Issuer");
                var audience = _configuration.GetValue<string>("Jwt:Audience");
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:Key"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                return Ok(stringToken);
            }
            return Unauthorized();
        }
    }
}
