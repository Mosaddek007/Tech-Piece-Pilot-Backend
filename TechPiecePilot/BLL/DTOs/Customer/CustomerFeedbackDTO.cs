using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Customer
{
    public class CustomerFeedbackDTO : CustomerDTO
    {
        public List<FeedbackDTO> Feedbacks { get; set; }

        public CustomerFeedbackDTO()
        {
            Feedbacks = new List<FeedbackDTO>();
        }

    }
}

