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
        public IActionResult Order1_Add(Order model)
        {
            if (HttpContext.Session.GetInt32("User_Login_Key") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            model.User_No = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());
            model.Product_Code = "1001";
            model.Product_Name = "매화당의";
            model.Product_Cost = "89000";
            model.Order_Time = DateTime.Now;

           


            using (var db = new DBServer())
                {
                    
                    db.Orders.Add(model);
                    if (db.SaveChanges() > 0)
                    {
                   
                    return RedirectToAction("OrderSuccess1", "ProductOrder");               
                }

            }
            return View();
        }

        [HttpPost]
        public IActionResult Order2_Add(Order model)
        {
            if (HttpContext.Session.GetInt32("User_Login_Key") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            model.User_No = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());
            model.Product_Code = "1002";
            model.Product_Name = "은비당의 옥색";
            model.Product_Cost = "109000";
            model.Order_Time = DateTime.Now;

            using (var db = new DBServer())
            {

                db.Orders.Add(model);
                if (db.SaveChanges() > 0)
                {
                    
                    return RedirectToAction("OrderSuccess2", "ProductOrder");
                }


            }
            return View();
        }

        [HttpPost]
        public IActionResult Order3_Add(Order model)
        {
            if (HttpContext.Session.GetInt32("User_Login_Key") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            model.User_No = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());
            model.Product_Code = "1003";
            model.Product_Name = "설중산호";
            model.Product_Cost = "99000";
            model.Order_Time = DateTime.Now;

            using (var db = new DBServer())
            {

                db.Orders.Add(model);
                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("OrderSuccess3", "ProductOrder");
                }


            }
            return View();
        }

        [HttpPost]
        public IActionResult Order4_Add(Order model)
        {
            if (HttpContext.Session.GetInt32("User_Login_Key") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            model.User_No = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());
            model.Product_Code = "2001";
            model.Product_Name = "산호핑크";
            model.Product_Cost = "99000";
            model.Order_Time = DateTime.Now;

            using (var db = new DBServer())
            {

                db.Orders.Add(model);
                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("OrderSuccess4", "ProductOrder");
                }


            }
            return View();
        }

        [HttpPost]
        public IActionResult Order5_Add(Order model)
        {
            if (HttpContext.Session.GetInt32("User_Login_Key") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            model.User_No = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());
            model.Product_Code = "2002";
            model.Product_Name = "베리예빔";
            model.Product_Cost = "119000";
            model.Order_Time = DateTime.Now;

            using (var db = new DBServer())
            {

                db.Orders.Add(model);
                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("OrderSuccess5", "ProductOrder");
                }


            }
            return View();
        }

        [HttpPost]
        public IActionResult Order6_Add(Order model)
        {
            if (HttpContext.Session.GetInt32("User_Login_Key") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            model.User_No = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());
            model.Product_Code = "2003";
            model.Product_Name = "민달래";
            model.Product_Cost = "109000";
            model.Order_Time = DateTime.Now;

            using (var db = new DBServer())
            {

                db.Orders.Add(model);
                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("OrderSuccess6", "ProductOrder");
                }


            }
            return View();
        }
        public IActionResult OrderSuccess1()
        {
            ViewData["User_No"] = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());
            ViewData["Product_Name"] = "매화당의";
            ViewData["Order_Time"] = DateTime.Now; ;
            ViewData["Product_Cost"] = "109000";
            return View();
        }

        public IActionResult OrderSuccess2()
        {
            ViewData["User_No"] = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());
            ViewData["Product_Name"] = "매화당의";
            ViewData["Order_Time"] = DateTime.Now; ;
            ViewData["Product_Cost"] = "109000";
            return View();
        }

        public IActionResult OrderSuccess3()
        {
            ViewData["User_No"] = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());
            ViewData["Product_Name"] = "매화당의";
            ViewData["Order_Time"] = DateTime.Now; ;
            ViewData["Product_Cost"] = "109000";
            return View();
        }

        public IActionResult OrderSuccess4()
        {
            ViewData["User_No"] = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());
            ViewData["Product_Name"] = "매화당의";
            ViewData["Order_Time"] = DateTime.Now; ;
            ViewData["Product_Cost"] = "109000";
            return View();
        }

        public IActionResult OrderSuccess5()
        {
            ViewData["User_No"] = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());
            ViewData["Product_Name"] = "매화당의";
            ViewData["Order_Time"] = DateTime.Now; ;
            ViewData["Product_Cost"] = "109000";
            return View();
        }

        public IActionResult OrderSuccess6()
        {
            ViewData["User_No"] = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());
            ViewData["Product_Name"] = "매화당의";
            ViewData["Order_Time"] = DateTime.Now; ;
            ViewData["Product_Cost"] = "109000";
            return View();
        }

        public IActionResult Order1()
        {
            return View();
        }

        public IActionResult Order2()
        {
            return View();
        }
        public IActionResult Order3()
        {
            return View();
        }

        public IActionResult Order4()
        {
            return View();
        }

        public IActionResult Order5()
        {
            return View();
        }

        public IActionResult Order6()
        {
            return View();
        }

        public IActionResult Order7()
        {
            return View();
        }

        public IActionResult Order8()
        {
            return View();
        }

        public IActionResult Order9()
        {
            return View();
        }

       


        public IActionResult Product_Order()
        {
            return View();
        }

      

    }
}
