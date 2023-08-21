using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string CatName { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }
        public CategoryModel() 
        { 
            Products = new List<ProductModel>();
        }
    }

}
