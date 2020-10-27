using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Dalgucci
{
    public class Program
    {
        static TcpIpServer server = null;
<<<<<<< HEAD
        //static public Database data = null;
        public static void Main(string[] args)
        {
            server = new TcpIpServer();
           // data = new Database();
=======
       // static public Database data = null;
        public static void Main(string[] args)
        {
            server = new TcpIpServer();
            //data = new Database();
>>>>>>> 9d548fa9844d170ec14d6e309b87e57261fca033
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

