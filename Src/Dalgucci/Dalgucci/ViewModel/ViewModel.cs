using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dalgucci.Models;

namespace Dalgucci.ViewModel
{
    public class LoginViewModel
    {

        [Required]
        public string User_ID { get; set; }
        [Required]
        public string Pwd { get; set; }
    }

    public class Manager_LoginViewModel
    {

        [Required]
        public string Manager_ID { get; set; }
        [Required]
        public string Manager_Pwd { get; set; }
    }

    public class Product_Select
    {

        [Required]
        public string Product_Code { get; set; }

        [Required]
        public string Quantity { get; set; }

    }


 
}
