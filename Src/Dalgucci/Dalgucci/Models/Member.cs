using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dalgucci.Models
{
   
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_No { get; set; }
        [Required]
        public string User_ID { get; set; }
        [Required]
        public string Pwd { get; set; }
        [Required]
        public string User_name { get; set; }
        [Required]
        public string Tel { get; set; }
        [Required]
        public string RRN { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
    }

    public class Manager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Manager_No { get; set; }
        [Required]
        public string Manager_ID { get; set; }
        [Required]
        public string Manager_Pwd { get; set; }
        [Required]
        public string Manager_name { get; set; }
        [Required]
        public string Manager_Tel { get; set; }
        [Required]
        public string Manager_RRN { get; set; }
        [Required]
        public string Manager_Address { get; set; }
        [Required]
        public string Manager_Email { get; set; }
    }
   
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
 
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_No { get; set; }
        [Required]
        public string Product_Code { get; set; }
     
        public virtual Product Product { get; set; }
        [Required]
        public int User_No { get; set; }
       
        public virtual Member Member { get; set; }

       
        public DateTime Order_Time { get; set; }
    }


}
