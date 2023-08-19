using BLL.DTOs.Customer;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.CustomerServices
{
    public class WishlistServices
    {
        //GET All Wishlist
        public static List<WishlistDTO> GetWishlist()
        {
            var data = DAL.DataAccessLayer.WishlistData().Read();
            var returndata = new List<WishlistDTO>();
            foreach (var item in data)
            {
                var data1 = new WishlistDTO()
                {
                    WishID = item.WishID,
                    CustomerID = item.CustomerID,
                    ProductID = item.ProductID

                };
                returndata.Add(data1);

            }
            return returndata;

        }
        //POST wishlist
        public static WishlistDTO CreateWishlist(WishlistDTO obj)
        {
            var data1 = new WishlistModel()
            {
                CustomerID = obj.CustomerID,
                ProductID = obj.ProductID
            };
            var data = DAL.DataAccessLayer.WishlistData().Create(data1);

            if (data != null)
            {
                obj.WishID = data.WishID;
                return obj;
            }
            else
            {
                return null;
            }

        }
  
        //wishlist Delete
        public static bool DeleteWishlist(int id)
        {

            var data = DAL.DataAccessLayer.WishlistData().Delete(id);

            return data;

        }
    }
}
