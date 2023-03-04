using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TactSoft.Core.Model;
using TactSoft.Core.Model.Account;

namespace TactSoft.Data.Data
{
    public class ApplicationDb:DbContext
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options):base(options)
        {

        }
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<CareerModel> Careers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NoticePeriod> NoticePeriods { get; set; }
        public DbSet<UserModel> users { get; set; }
    }
}
