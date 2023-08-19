using BLL.DTOs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;

namespace BLL.Services
{
    public class AuthService
    {
        private static object configuration;

        public static UserDTO GetAuth(string username,string password)
        {
            var data = DAL.DataAccessLayer.Auth().Authenticate(username, password);
            var user = new UserDTO()
            {
                UserID = data.UserID,
                Username = data.Username,
                Firstname = data.Firstname,
                Lastname = data.Lastname,
                DOB = data.DOB,
                Email = data.Email,
                Phone = data.Phone,
                Gender = data.Gender,
                Role = data.Role
            };
            return user;
        }
        
        
    }
}
