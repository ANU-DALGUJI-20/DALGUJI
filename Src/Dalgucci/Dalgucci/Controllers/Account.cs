using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dalgucci.Models;

using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Http;
using Dalgucci.DB;
using System.Web;
using Dalgucci.ViewModel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Data.SqlClient;
using Member = Dalgucci.Models.Member;
using Newtonsoft.Json.Converters;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace Dalgucci.Controllers
{
    public class Account : Controller
    {

        [HttpGet]
        public IActionResult Sign_up()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Sign_up(Member model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DBServer())
                {
                    db.Members.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Sign_upComplete");
            }
            return View(model);
        }

        public IActionResult Sign_upComplete()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel models)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DBServer())
                {
                    var user = db.Members.FirstOrDefault(u => u.User_ID.Equals(models.User_ID) && u.Pwd.Equals(models.Pwd));

                    if (user != null)
                    {
                        HttpContext.Session.SetInt32("User_Login_Key", user.User_No);

                        return RedirectToAction("LoginSuccess", "Account");
                    }
                }
                ViewBag.Message = "실패";
            }
            return View(models);
        }
        public IActionResult LoginSuccess(LoginViewModel models)
        {

            return View();

        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User_Login_Key");
            return RedirectToAction("Main", "Web");

        }


       

        public IActionResult Index(Order models)
        {

            using (var db = new DBServer())
            {

                var user = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());
                using (SqlCommand sqlcomm = new SqlCommand($"select * from Order where {user}"))
                {
                    var list = db.Orders.ToList();
                    return View(list);
                }


               
            }

        }

    }

}
