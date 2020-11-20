using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        //comment
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthController));
        private readonly UserDbContext _context;
        private IConfiguration _config;
        public AuthController(UserDbContext userDbContext,IConfiguration configuration)
        {
            _config = configuration;
            _context = userDbContext;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            _log4net.Info("get request initiated");
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok();
        }
        // GET: api/<AuthController>
        [HttpPost("User")]
        public User GetUser(User valuser)
        {
            var user = _context.Users.FirstOrDefault(c => c.Username == valuser.Username && c.Password == valuser.Password);

            if (user == null)
            {

                return null;
            }

            return user;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] User login)
        {
            _log4net.Info("Authentication initiated");

            IActionResult response = Unauthorized();
            User user = GetUser(login);
            if (user == null)
            {
                _log4net.Info("User Not Found");
                return NotFound();
            }
            
            else
            {


                var tokenString = GenerateJSONWebToken(login);
                response = Ok(new { token = tokenString });
                _log4net.Info("Json web token generated");


                return response;
            }
        }
        private string GenerateJSONWebToken(User userInfo)
        {
           
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddSeconds(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
