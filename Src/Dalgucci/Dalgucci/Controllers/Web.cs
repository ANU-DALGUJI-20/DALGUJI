using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Dalgucci.ViewModel;
using Dalgucci.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Dalgucci.DB;
using Microsoft.AspNetCore.Http;

namespace Dalgucci.Controllers
{
    public class Web : Controller
    {

        public IActionResult Main()
        {
            ViewData["User"] = "로그인을 해줘";
            return View();
        }

        [HttpPost]
        public IActionResult Main(string MemberID)
        {
            ViewData["User"] = MemberID;
            
            return View();
        }


        public IActionResult ProductPage(string Code)
        {
            return View();
        }

      

    }
}
