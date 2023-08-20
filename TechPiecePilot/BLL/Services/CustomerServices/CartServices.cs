using BLL.DTOs.Customer;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.CustomerServices
{
    public class CartServices
    {
        //POST Users
        public static CartDTO CreateCart(CartDTO obj)
        {
            var allcart = GetCarts();
            var exsistingcart = allcart.Where(e => e.Username == obj.Username && e.ProductID == obj.ProductID).SingleOrDefault();
            if (exsistingcart != null)
            {
                obj.CartID = exsistingcart.CartID;
                //obj.Quantity += exsistingcart.Quantity;
                //obj.Price += exsistingcart.Price;
                obj.Status = exsistingcart.Status;
                var data =  UpdateCart(obj);
                return data;
            }
            else
            {
                var data1 = new CartModel()
                {
                    Status = "Pending",
                    ProductID = obj.ProductID,
                    Username = obj.Username,
                    Quantity = obj.Quantity,
                    Price = obj.Price

                };

                var data = DAL.DataAccessLayer.CartData().Create(data1);
                return obj;
            }

            

            //if (data != null)
            //{
            //    obj.CartID = data.CartID;
            //    return obj;
            //}
            //else
            //{
            //    return null;
            //}

        }
        // Update user
        public static CartDTO UpdateCart(CartDTO obj)
        {

            var data1 = new CartModel()
            {
                CartID = obj.CartID,
                Status = obj.Status,
                ProductID = obj.ProductID,
                Username = obj.Username,
                Quantity = obj.Quantity,
                Price = obj.Price

            };

            var data = DAL.DataAccessLayer.CartData().Update(data1);

            if (data != null)
            {
                return obj;
            }
            else
            {
                return null;
            }

        }
        //Get all carts
        public static List<CartDTO> GetCarts()
        {
            var data = DAL.DataAccessLayer.CartData().Read();
            var returndata = new List<CartDTO>();
            foreach (var item in data)
            {
                var data1 = new CartDTO()
                {
                    CartID = item.CartID,
                    Status = item.Status,
                    ProductID = item.ProductID,
                    Username = item.Username,
                    Quantity = item.Quantity,
                    Price = item.Price
                };
                returndata.Add(data1);

            }
            return returndata;
        }
    }
}
