using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Customer
{
    public class CartDTO
    {
        public int CartID { get; set; }

        //Should be (Cancel/Processing for admin / On Cart(customer))
        public string Status { get; set; }

        //ForeignKey From ProductModel
       // [ForeignKey("Product")]
        public int ProductID { get; set; }

        //ForeignKey From UserModel
        //[ForeignKey("User")]
        public string Username { get; set; }

        //By Default 1 ashbe
        public int Quantity { get; set; }

        public int Price { get; set; }
    }
}
