using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TokenModel
    {
        [Key]
        public int TokenID { get; set; }
        public string TokenKey { get; set; }
        [Required]
     
        public DateTime CreatedAt { get; set; }

        public DateTime? Expired { get; set; }
        [Required]
        public string Username { get; set; }

        public string Role { get; set; }


    }
}
