using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class Auth :Repos, Interfaces.IAuth<UserModel>
    {
        public UserModel Authenticate(string username, string password)
        {
            var data = db.UserModels.Where(e => e.Username.Equals(username) && e.Password.Equals(password)).SingleOrDefault();
            return data;
        }
    }
}
