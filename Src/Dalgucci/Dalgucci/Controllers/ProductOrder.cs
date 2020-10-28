using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dalgucci.DB;
using Dalgucci.Models;
using Dalgucci.ViewModel;
using DocumentFormat.OpenXml.Office.CustomUI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;

namespace Dalgucci.Controllers
{
    public class ProductOrder : Controller
    {
        public IActionResult OrderList()
        {
            if(HttpContext.Session.GetInt32("User_Login_Key")== null)
            {
                return RedirectToAction("Login","Account");
            }
            using (var db = new DBServer())
            {
                var list = db.Orders.ToList();
                return View(list);
            }
        }
        [HttpGet]
        public IActionResult Add()
        {
            if (HttpContext.Session.GetInt32("User_Login_Key") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Add(Order model)
        {
            if (HttpContext.Session.GetInt32("User_Login_Key") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            model.User_No = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());
            model.Product_Code = "1001";
            //model.User_No = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());
            model.Order_Time = DateTime.Now;
         
                using (var db = new DBServer())
                {
                   
                    db.Orders.Add(model);
                    if (db.SaveChanges() > 0)
                    {
                        return RedirectToAction("OrderSuccess","ProductOrder");
                    }
                
                
            }
            return View();
        }



        public IActionResult OrderSuccess()
        {
            return View();
        }

      
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
