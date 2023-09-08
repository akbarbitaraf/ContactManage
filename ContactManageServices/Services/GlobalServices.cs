using ContactManageEntities.DB;
using ContactManageRepositories;
using ContactManageServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManageServices.Services
{
    public class GlobalServices : IGlobalServices
    {
        public ContactManageContext _contactManageContext;
        public GlobalServices(ContactManageContext contactManageContext)
        {
            _contactManageContext = contactManageContext;
        }
        public async Task SeedBaseTable()
        {
            //Fill Table Contact Types 
            var ContactTypes =await _contactManageContext.ContactTypes.AsNoTracking().ToListAsync();
            if (!ContactTypes.Any())
            {
                var listContactTypes = new List<ContactTypes>();
                listContactTypes.Add(new ContactTypes()
                {
                    Id = 0,
                    Title = "ضروری"
                });
                listContactTypes.Add(new ContactTypes()
                {
                    Id = 1,
                    Title = "عادی"
                });
                listContactTypes.Add(new ContactTypes()
                {
                    Id = 2,
                    Title = "امدادی"
                });
                await _contactManageContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.ContactTypes ON");
                await _contactManageContext.AddRangeAsync(listContactTypes);
                await _contactManageContext.SaveChangesAsync();
                await _contactManageContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.ContactTypes OFF");
            }


        }
    }
}
