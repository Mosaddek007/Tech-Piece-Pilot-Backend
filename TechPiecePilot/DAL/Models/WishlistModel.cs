using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class WishlistModel
    {
        [Key]
        public int WishID { get; set; }

        //ForeignKey From UserModel  Autofill ..No Need To Put Required
        [ForeignKey("User")]
        public int CustomerID { get; set; }

        //ForeignKey From ProductModel Autofill ..No Need To Put Required
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public virtual UserModel User { get; set; }
        public virtual ProductModel Product { get; set; }

    }

}
