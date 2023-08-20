using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CartModel
    {
        [Key]
        public int CartID { get; set; }

        //Should be (Cancel/Processing for admin / On Cart(customer))
        public string Status { get; set; }

        //ForeignKey From ProductModel
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        //ForeignKey From UserModel
        [ForeignKey("User")]
        public string Username { get; set; }

        //By Default 1 ashbe
        public int Quantity { get; set; }

        public int Price { get; set; }
        public virtual ProductModel Product { get; set; }
        public virtual Customer User { get; set; }
    }

}
