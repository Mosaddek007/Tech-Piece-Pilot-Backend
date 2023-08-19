using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.AdminDTOs
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }

        public string ProductPicture { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string ProductStatus { get; set; }
        public int CategoryID { get; set; }
    }
}
