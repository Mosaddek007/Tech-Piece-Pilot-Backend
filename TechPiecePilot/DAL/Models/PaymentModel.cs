using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PaymentModel
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public String PaymentType { get; set; }

        //ForeighKey From CartModel
        //[ForeignKey("Cart")]
       // public int GrandTotal { get; set; }

        //ShoulAutogenrated
        public int InvoiceID { get; set; }

        [ForeignKey("User")]
        public string Username { get; set; }
        public virtual Customer User { get; set; }
        public virtual CartModel Cart { get; set; }
    }

}
