using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dalgucci.Models;

using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Http;
using Dalgucci.DB;

using Dalgucci.ViewModel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Data.SqlClient;
using Member = Dalgucci.Models.Member;

// test
namespace Dalgucci.Controllers
{
    public class Account : Controller 
    {
        [HttpGet]
        public IActionResult Sign_up()
        {
            //Program.data.InsertMember(MemberID, Password, User_name, Tel, RRN, Address, Email);
            return View();
        }

        
        [HttpPost]
        public IActionResult Sign_up(Member model)
        {
           if (ModelState.IsValid)
            {
                using(var db = new DBServer())
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

        //[HttpPost]
        //public IActionResult Sign_up(string MemberID, string Password, string User_name, string Tel, string RRN, string Address, string Email)
        //{
        //    Program.data.InsertMember(MemberID, Password, User_name, Tel, RRN, Address, Email);
        //    //return MemberID + Password + User_name + Tel + RRN + Address + Email;
        //    return View("Sign_upComplete");
        //}

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

                        return RedirectToAction("LoginSuccess","Account");
                    }
                   
                }
                return RedirectToAction("LoginFails","Account");
               

           
            }
            return View(models);
        }
        public IActionResult LoginSuccess()
        {

            return View();

        }
        public IActionResult LoginFails()
        {

            return View();

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User_Login_Key");
            return RedirectToAction("Main", "Web");

        }
        [HttpGet]
        public IActionResult Manager_Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Manager_Login(Manager_LoginViewModel model)

        {
            if (ModelState.IsValid)
            {
                using (var db = new DBServer())
                {
                    var user = db.Managers.FirstOrDefault(u => u.Manager_ID.Equals(model.Manager_ID) &&
                    u.Manager_Pwd.Equals(model.Manager_Pwd));

                    if (user != null)
                    {
                        HttpContext.Session.SetInt32("User_Login_Key", user.Manager_No);

                        return RedirectToAction("ManagerPage","Web");
                    }
                }
                ModelState.AddModelError(string.Empty, "회원정보가 올바르지 않아");
            }
            return View(model);
        }

        public IActionResult ManagerLogout()
        {
            HttpContext.Session.Remove("Manager_Login_key");
            return RedirectToAction("ManagerPage", "Web");

        }

       


        //[HttpPost]

        //public IActionResult Login(string MemberID, string Password)
        //{
        //    bool tru = Program.data.Sign_in(MemberID, Password);
        //    if (tru == true) {

        //        // ViewData["User"] = MemberID;
        //        return View("LoginSuccess");
        //}
        //    else
        //        return View("LoginFails");

        //    //return MemberID + Password ;
        //}
       

        

        //public IActionResult Register()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Register(Member member)
        //{

        //    member.Submit();
        //    return View("RegisterComplete", member);
        //}
    }
}
