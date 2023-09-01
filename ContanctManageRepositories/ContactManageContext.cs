using ContanctManageEntities.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContanctManageRepositories
{
    public class ContactManageContext : DbContext
    {
        public ContactManageContext(DbContextOptions<ContactManageContext> options) : base(options) { }
        public DbSet<Contacts> contacts { get; set; }
        public DbSet<Phone> phones { get; set; }

    }
 
}
