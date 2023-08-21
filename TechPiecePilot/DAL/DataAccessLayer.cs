using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using DAL.Repos.AdminRepos;
using DAL.Repos.CustomerRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DataAccessLayer
    {
        public static IRepos<ProductModel, int, ProductModel> N_ProductData()
        { 
            return new ProductRepo();
        }
        public static IRepos<Customer, string, Customer> CustomerData()
        {
            return new CustomerRepo();
        }
        public static IRepos<WishlistModel, int, WishlistModel> WishlistData()
        {
            return new WishlistRepo();
        }

        public static IRepos<CartModel, int, CartModel> CartData()
        {
            return new CartRepo();
        }


        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }

        public static IRepos<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
        public static IRepos<User, string, User> UserData()
        {
            return new UserRepo();
        }

        public static IRepos<FeedbackModel, int, FeedbackModel> FeedbackData()
        {
            return new FeedbackRepo();
        }
    }
}
