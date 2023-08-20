using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ReviewsModel
    {
        [Key]
        public int ReviewID { get; set; }

        [Required]
        public string Description { get; set; }

        //ForeignKey From UserModel Autofill ..No Need To Put Required
        [ForeignKey("User")]
        public string Username { get; set; }

        //ForeignKey From OrderModel Autofill ..No Need To Put Required
       // [ForeignKey("Order")]
        //public int OrderID { get; set; }

        //ForeignKey From ProductModel Autofill ..No Need To Put Required
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        public virtual Customer User { get; set; }
       // public virtual OrderModel Order { get; set; }
        public virtual ProductModel Product { get; set; }

    }
}