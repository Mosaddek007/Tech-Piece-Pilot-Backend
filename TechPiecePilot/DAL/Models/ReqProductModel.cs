using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ReqProductModel
    {
        [Key]
        public int ReqID { get; set; }

        //New product...So No connection To Productmodel
        public string ProductName { get; set; }

        //ForeignKey From CategoryModel  Should Be ScrollDown Dynamic Option
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        //ForeignKey From UserModel
        [ForeignKey("User")]
        public string Username { get; set; }

        public virtual Customer User { get; set; }
        public virtual CategoryModel Category { get; set; }
    }

}
