using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TokenDTO
    {
    
        public int TokenID { get; set; }
        public string TokenKey { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? Expired { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }
    }
}
