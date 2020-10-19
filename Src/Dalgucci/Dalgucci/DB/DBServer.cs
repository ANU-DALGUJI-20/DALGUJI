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
        public DbSet<Manager> Managers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.30;Database=SF1team;User Id=sa;Password=0924;");
        }




    }

}
