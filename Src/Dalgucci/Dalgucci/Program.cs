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
       // static public Database data = null;
=======

     

>>>>>>> a380754f8988c7837cbd164e7db55c12b276e312
        public static void Main(string[] args)
        {
            server = new TcpIpServer();
            //data = new Database();
<<<<<<< HEAD
=======

>>>>>>> a380754f8988c7837cbd164e7db55c12b276e312
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

