using OZ.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OZ.Interfaces;

namespace OZ.Api.Controllers
{
    [Route("api/Token")]
    public class TokenController : Controller
    {
        private IConfiguration _config;
        IUserMap userMap;
        public TokenController(IConfiguration config, IUserMap map)
        {
            _config = config;
            userMap = map;
        }
        [AllowAnonymous]
        [HttpPost]
        public dynamic Post([FromBody]LoginViewModel login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);
            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { userid = user.OID, 
                    place = user.PlaceID, 
                    FullName = user.FullName,
                    isAdmin = user.Admin,
                    token = tokenString });
            }
            return response;
        }
        private string BuildToken(UserViewModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddDays(365),
              signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private UserViewModel Authenticate(LoginViewModel login)
        {           
            UserViewModel user = userMap.CheckLogin(login.username, login.password);
            //if (login.username == "hainm" && login.password == "123")
            //{
            //    user = new UserViewModel { FullName = "Hai Nguyen" };
            //}
            return user;
        }
    }
}
