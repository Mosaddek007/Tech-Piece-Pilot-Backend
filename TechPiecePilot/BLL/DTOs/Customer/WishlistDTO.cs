using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Customer
{
    public class WishlistDTO
    {
        public int WishID { get; set; }
        public string Username { get; set; }
        //ForeignKey From ProductModel Autofill ..No Need To Put Required
        public int ProductID { get; set; }
        
    }
}
