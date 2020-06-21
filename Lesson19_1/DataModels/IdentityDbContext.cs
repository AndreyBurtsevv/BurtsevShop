using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.DataModels
{
    public class IdentityDbContext : IdentityDbContext<UserData>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext>  option) : base(option)
        {
            Database.Migrate();
        }
    }
}
