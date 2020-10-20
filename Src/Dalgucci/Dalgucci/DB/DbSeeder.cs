using Dalgucci.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dalgucci.DB
{
    public class DbSeeder
    {
        private DBServer _context;

        public DbSeeder(DBServer context)
        {
            _context = context;
        }
        public async Task SeedDatabase()
        {
            if (!_context.Members.Any())
            {
                List<Member> Members = new List<Member>()
                {
                    new Member() { User_ID="suk0924", User_name="중석", Pwd="123", Address="123", RRN="123", Tel="123", Email="123"}
                };
                await _context.AddRangeAsync(Members);
                await _context.SaveChangesAsync();
            }
        }

    }
}
