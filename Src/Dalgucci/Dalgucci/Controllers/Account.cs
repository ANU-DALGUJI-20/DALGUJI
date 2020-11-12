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
        public IActionResult Login(LoginViewModel models )
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
                //return RedirectToAction("LoginFails","Account");
                //message.JavascriptToRun = "ShowError()";
                ViewBag.Message = "실패";
                //ViewData["message"] = "잘못되었음";
            }
            return View(models);
        }
        public IActionResult LoginSuccess(LoginViewModel models)
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
