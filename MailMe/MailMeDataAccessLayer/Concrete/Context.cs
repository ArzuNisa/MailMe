using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailMeEntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MailMeDataAccessLayer.Concrete
{
    public class Context: IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=91.151.83.102;Port=5432;Database=MailMe;User Id=ikragulkocakteam;Password=Uzk1djYNjZnSzO*jaf9JxQOIk;");
        }
        public DbSet<PersonalAccount> PersonalAccounts { get; set; }
        public DbSet<PersonalAccountProcess> PersonalAccountProcesses { get; set; }
        
    }
}
