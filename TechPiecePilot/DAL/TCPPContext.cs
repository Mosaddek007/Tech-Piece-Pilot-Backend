using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TCPPContext : DbContext
    {
        public TCPPContext() : base() { }          
        public DbSet<CartModel> CartModels { get; set; }
        public DbSet<CategoryModel> CategoryModels { get; set; }
        public DbSet<FeedbackModel> FeedbackModels { get; set; }
        //public DbSet<OrderModel> OrderModels { get; set; }
        //public DbSet<PaymentModel> PaymentModels { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ReqProductModel> ReqProductModels { get; set; }
        //public DbSet<ReviewsModel> ReviewsModels { get; set; }
        //public DbSet<UserModel> UserModels { get; set; }
        public DbSet<WishlistModel> WishlistModels { get; set; }
        //public DbSet<HistoryModel> HistoryModels { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }
          

    }

}
