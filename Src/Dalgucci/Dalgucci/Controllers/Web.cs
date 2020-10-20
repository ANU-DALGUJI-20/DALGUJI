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

        [HttpPost]
        public IActionResult Login(Product_Select model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DBServer())
                {
                    var user = db.Products.FirstOrDefault(u => u.Product_Code.Equals(model.Product_Code) && u.Quantity.Equals(model.Quantity));

                    if (user != null)
                    {
                        
                    }
                }
                ModelState.AddModelError(string.Empty, "회원정보가 올바르지 않아");
            }
            return View(model);
        }


    }
}
