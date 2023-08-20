using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class FeedbackModel
    {
        [Key]
        public int FeedbackID { get; set; }
        public string Description { get; set; }

        //ForeignKey From UserModel
        [ForeignKey("User")]
        public string Username { get; set; }

        //shuld be nullable from customer...and will be updated from admin thanking the customer
        public string ReplyFromAdmin { get; set; }

        public virtual Customer User { get; set; }

    }

}
