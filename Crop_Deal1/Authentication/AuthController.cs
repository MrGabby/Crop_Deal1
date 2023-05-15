
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Crop_Deal1.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    { 
        public static LoginUser user=new LoginUser();
        private readonly IConfiguration _configuration;
      //  private readonly IUserService _userService;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
           // _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginUser>>Register(Logindto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
              user.Username= request.Username;
                user.PasswordHash = passwordHash;
               user.PasswordSalt = passwordSalt;

            return Ok(user);
         }

        [HttpPost("login")]
        public async Task<ActionResult<string>>Login(Logindto request)
        {
            if (user.Username != request.Username)
            {
                return BadRequest("User Not Found");
            }

            if(!VerifyPasswordHash(request.Password,user.PasswordHash,user.PasswordSalt))
            {
                return BadRequest("Invalid Password");
            }
            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(LoginUser user)
        {
            List<Claim> claims = new List<Claim>
             {
                 new Claim(ClaimTypes.Name,user.Username),
                 new Claim(ClaimTypes.Role,"Admin")
             };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                 _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
          claims: claims,
          expires: DateTime.Now.AddDays(1),
          signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


        private void CreatePasswordHash(string password,out byte[]passwordHash, out byte[] passwordSalt)
        {
             
            using (var hmac= new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
