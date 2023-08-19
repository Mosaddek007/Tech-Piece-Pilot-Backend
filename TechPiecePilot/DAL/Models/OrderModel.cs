using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderID { get; set; }

        //Should To Current Date After Payment 
        public DateTime Date { get; set; }

        // Status Shoul be (Payment/Processing/Delivered)
        public string Status { get; set; }

        //ForeignKey From CartModel
        [ForeignKey("Cart")]
        public int CartID { get; set; }

        //ForeignKey From ProductModel       ???????????????????
        public int Productlist { get; set; }

        //ForeignKey From UserModel
        [ForeignKey("User")]
        public int CustomerID { get; set; }

        public virtual CartModel Cart { get; set; }
        public virtual UserModel User { get; set; }


    }

}
