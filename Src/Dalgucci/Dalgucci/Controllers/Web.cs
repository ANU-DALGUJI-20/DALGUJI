using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Dalgucci.Models;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace Dalgucci.Controllers
{
    public class Web : Controller
    {
        
        public IActionResult Main()
        {
            ViewData["Name"] = "박중석";
            return View();
        }

        [HttpPost]
        public IActionResult Sign_up(Member model)
        {
            Branch b
            return View();
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
        //protected void
        public string Index()
        {
            return "This is my <b>default</b> action...";
        }

        // 
        // GET: /HelloWorld/Welcome/ 
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
       
    }
}
