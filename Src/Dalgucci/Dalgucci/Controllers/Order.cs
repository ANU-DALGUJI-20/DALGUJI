using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dalgucci.DB;
using Dalgucci.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Dalgucci.Controllers
{
    public class Order : Controller
    {
        public IActionResult Product_Order()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Product_Select(Product_Select model)
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
