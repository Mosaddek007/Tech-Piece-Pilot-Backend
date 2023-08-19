using BLL.DTOs;
using BLL.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Configuration;

namespace TechPiecePilot.Auth
{
    public class Auth
    {


        //private AuthService authData;
        //public Auth(AuthService authData)
        //{
        //    this.authData = authData;
        //}
        public static TokenDTO getAuth(string username, string password)
        {
            var data = AuthService.GetAuth(username, password);
            if (data != null)
            {
                var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,username)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Convert.ToString(ConfigurationManager.AppSettings["config:JwtKey"])));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddDays(Convert.ToDouble(Convert.ToString(ConfigurationManager.AppSettings["config:JwtExpireDays"])));
                var token = new JwtSecurityToken(
                    Convert.ToString(ConfigurationManager.AppSettings["config:JwtIssuer"]),
                    Convert.ToString(ConfigurationManager.AppSettings["config:JwtAudience"]),
                    claims,
                    expires: expires,
                    signingCredentials: creds
                    );
                var Token =  new JwtSecurityTokenHandler().WriteToken(token);
                var tokendata = new TokenDTO()
                {
                    TokenKey = Token,
                    Role = data.Role,
                    CreatedAt = DateTime.Now,
                    Expired = null,
                    Username = data.Username
                    
                };
                return tokendata;
            }
            return null;

        }
    }
}