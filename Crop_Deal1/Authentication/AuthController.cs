
using Crop_Deal1.Dtos;
using Crop_Deal1.Interface;
using Crop_Deal1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Crop_Deal1.Authentication   
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUser repo;

        public static LoginUser user=new LoginUser();
        private readonly IConfiguration _configuration;
      //  private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, IUser repo)
        {
            _configuration = configuration;
            this.repo = repo;
            // _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginUser>> Register(Userdto userd)
        {
            CreatePasswordHash(userd.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User()
            {
                Name = userd.Name,
                // Password = userd.Password,
                Email_id = userd.Email_id,
                Contact = userd.Contact,
                Address = userd.Address,
                Roles = userd.Roles,
                Is_subscribe = userd.Is_subscribe,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            user = await repo.CreateUser(user);
            return Ok(user);
         }


/*        public HttpResponseMessage Get()
        {
            var resp = new HttpResponseMessage();

            var cookie = new CookieHeaderValue("session-id", "12345");
            cookie. = DateTimeOffset.Now.AddDays(1);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";

            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return resp;
        }
*/

        [HttpPost("login")]
        public async Task<ActionResult<string>>Login(Logindto request)
        {
             
            var username=request.Username;
            var user = await repo.FindUser(username);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Password is incorrect");
            }
            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            string role = "Dealer";
            if (user.Roles == "Admin")
            {
                role= user.Roles;
            }   if (user.Roles == "Farmer")
            {
                role= user.Roles;
            }
            
             
            List<Claim> claims = new List<Claim>
             {
                 new Claim(ClaimTypes.Name,user.Email_id),
                 new Claim(ClaimTypes.Role,role)
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
