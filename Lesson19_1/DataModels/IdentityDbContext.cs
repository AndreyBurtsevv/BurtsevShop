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

//dotnet ef migrations add AddUserId --project "C:\Users\Andrew\3D Objects\IT School\Show-Proj\Lesson19_1\Lesson19_1" --context MyDbContext
