using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Customer
{
   public class CustomerDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
