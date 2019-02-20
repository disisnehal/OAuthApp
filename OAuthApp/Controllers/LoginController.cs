using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OAuthApp.Models;
using OAuthApp.Models.DB;

namespace OAuthApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private static IConfiguration _config;
        private static string connectionString;

       // public object ReturnCodes { get; private set; }

        private ILoggerManager _logger;

        //public LoginController(ILoggerManager logger)
        //{
        //    _logger = logger;
        //}

        public LoginController(IConfiguration config, ILoggerManager logger)
        {
            _logger = logger;
            _config = config;
            connectionString = _config.GetConnectionString("DefaultConnection");
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]UserLogIn login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString + ", Username:" + user.UserName + ", EmailAddress:" + user.Email });
            }
            _logger.LogInfo("Token generated");
            return response;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult MyPage([FromBody]UserLogIn login)
        //{
        //    IActionResult response = Unauthorized();
        //    var user = AuthenticateUser(login);

        //    if (user != null)
        //    {
        //        var tokenString = GenerateJSONWebToken(user);
        //        response = Ok(new { token = tokenString + "Username:" + user.UserName + ",EmailAddress:" + user.Email });
        //    }

        //    return response;
        //}


        private string GenerateJSONWebToken(UserLogIn userInfo)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
              {
                  new Claim("UserName", userInfo.UserName)
              });
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(10),
              signingCredentials: credentials
              );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserLogIn AuthenticateUser(UserLogIn login)
        {
            //UserLogIn user = null;

            #region unnecessary

            //Validate the User Credentials  

            //if (login.Username == "Jignesh")
            //{
            //    user = new UserModel { Username = "Jignesh Trivedi", EmailAddress = "test.btest@gmail.com" };
            //}
            //return user;



            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //string sqlQuery = "SELECT * FROM UserLogIn WHERE Username= '" + login.Username + "'";
            //SqlCommand cmd = new SqlCommand(sqlQuery, con);

            //con.Open();

            //SqlDataReader rdr = cmd.ExecuteReader();
            //con.Close();
            // }

            #endregion

            SampleContext SampleEntities = new SampleContext();

            var User = SampleEntities.UserLogIn.FirstOrDefault(u => u.UserName == login.UserName
                 && u.Password == login.Password);

            if (User != null)
            {
                //_logger.LogInfo("Fetching user info");

                //throw new Exception("Exception while fetching  user info.");

                return User; 
            }

            else
            {
                //_logger.LogInfo("Fetching user info");

                //throw new Exception("Exception while fetching  user info.");

                return null;
            }
        }
    }
}