using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dalgucci.Models;
using Microsoft.EntityFrameworkCore;

namespace Dalgucci.DB 
{
    public class DBServer : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Product> Products { get; set; }
       
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=SF1team;User Id=sa;Password=0924;");
        }



    }

}
