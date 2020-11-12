using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dalgucci.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dalgucci.Controllers
{
    public class Order_Log : Controller
    {
        private string Dbconn = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;
        private List<Order> orders = new List<Order>();


       
    }
}
