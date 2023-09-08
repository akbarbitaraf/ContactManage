using ContactManageEntities.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManageRepositories
{
    public class ContactManageContext : DbContext
    {
        private readonly IMemoryCache _cache;
        public ContactManageContext(DbContextOptions<ContactManageContext> options , IMemoryCache cache) : base(options) {
            _cache = cache;

        }
        public DbSet<Contacts> contacts { get; set; }
        public DbSet<ContactTypes> ContactTypes { get; set; }



    }

}
