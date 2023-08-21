using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Customer
{
    public class FeedbackDTO
    {
        public int FeedbackID { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public string ReplyFromAdmin { get; set; }
       
    }
}
