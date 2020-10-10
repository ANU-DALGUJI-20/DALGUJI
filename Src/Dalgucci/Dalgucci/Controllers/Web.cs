using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dalgucci.Controllers
{
    public class Web : Controller
    {
        public IActionResult Main()
        {
            ViewData["Name"] = "박중석";
            return View();
        }

        public IActionResult Sign_up()
        {
           
            return View();
        }

        public IActionResult Join()
        {

            return View();
        }

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
