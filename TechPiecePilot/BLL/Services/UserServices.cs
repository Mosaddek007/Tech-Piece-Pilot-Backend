using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserServices
    {
        //GET All Users
        public static List<UserDTO> GetUsers()
        {
            var data = DAL.DataAccessLayer.N_UserData().Read();
            var returndata = new List<UserDTO>();
            foreach (var item in data)
            {
                var data1 = new UserDTO()
                {
                    UserID= item.UserID,
                    Username = item.Username,
                    Firstname = item.Firstname,
                    Lastname = item.Lastname,
                    Password=item.Password,
                    Role=item.Role,
                    DOB = item.DOB,
                    Email = item.Email,
                    Phone = item.Phone,
                    Gender = item.Gender
                };
                returndata.Add(data1);

            }
            return returndata;

        }
        // GET UserByID
        public static UserDTO GetUserByID(int id)
        {
            var data = DAL.DataAccessLayer.N_UserData().Read(id);
            //var Uitem = data.Find(item => item.UserID == id);
            if (data != null)
            {
                var product = new UserDTO()
                {
                    UserID = data.UserID,
                    Username = data.Username,
                    Firstname = data.Firstname,
                    Lastname = data.Lastname,
                    DOB = data.DOB,
                    Email = data.Email,
                    Phone = data.Phone,
                    Gender = data.Gender
                };
                return product;
            }
            return null;
        }
        //POST Users
        public static UserDTO CreateUser(UserDTO obj)
        {
            var data1 = new UserModel()
            {
                Username = obj.Username,
                Firstname = obj.Firstname,
                Lastname = obj.Lastname,
                DOB = obj.DOB,
                Email = obj.Email,
                Phone = obj.Phone,
                Gender = obj.Gender,
                Password = obj.Password,
                Role = obj.Role

            };
            var data = DAL.DataAccessLayer.N_UserData().Create(data1);

            if (data != null)
            {
                obj.UserID = data.UserID;
                return obj;
            }
            else
            {
                return null;
            }

        }
        // Update user
        public static UserDTO UpdateUSer(UserDTO obj)
        {
            var data1 = new UserModel()
            {
                UserID = obj.UserID,
                Username = obj.Username,
                Firstname = obj.Firstname,
                Lastname = obj.Lastname,
                DOB = obj.DOB,
                Email = obj.Email,
                Phone = obj.Phone,
                Gender = obj.Gender,
                Password = obj.Password,
                Role = obj.Role

            };
            var data = DAL.DataAccessLayer.N_UserData().Update(data1);

            if (data != null)
            {
                return obj;
            }
            else
            {
                return null;
            }

        } 
        //User Delete
        public static bool DeleteUser(int id)
        {

            var data = DAL.DataAccessLayer.N_UserData().Delete(id);

            return data;

        }

    }
}
