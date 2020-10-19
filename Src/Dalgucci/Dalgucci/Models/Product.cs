using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dalgucci.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Product_No { get; set; }
        [Required]
        public string Product_Code { get; set; }
        [Required]
        public string Product_Name { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public string Quantity { get; set; }
    }
}
