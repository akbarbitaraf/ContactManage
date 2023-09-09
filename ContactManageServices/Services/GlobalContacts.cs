using ContactManageEntities.DB;
using ContactManageEntities.DTO.Record;
using ContactManageEntities.Enum;
using ContactManageRepositories;
using ContactManageServices.Interfaces;
using ContactManageTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManageServices.Services
{
    public class GlobalContacts : IContact
    {
        private readonly ContactManageContext _contactManage;
        private readonly ILogger<GlobalContacts> _logger;
        private readonly IMemoryCache _cache;
        public GlobalContacts(ContactManageContext contactManage, ILogger<GlobalContacts> logger ,IMemoryCache cache)
        {

            _contactManage = contactManage;
            _logger = logger;
            _cache = cache;
        }
        public async Task<Contacts> CreateContact(Contacts contactReq)
        {
            await _contactManage.contacts.AddAsync(contactReq);
            var result = await _contactManage.SaveChangesAsync();
            contactReq.Id = result;
            return contactReq;
        }
  
        public async Task<Contacts> GetContactByID(int contactID)
        {
            var result =  await _contactManage.contacts.Where(x => x.Id == contactID).AsNoTracking().FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Contacts>> GetContacts()
        {
           return await _contactManage.contacts.AsNoTracking().ToListAsync();    
        }

        public async Task<List<Contacts>> GetContactsByFilter(ContactReq contactReq)
        {
            var cacheKey = $"Contact_{contactReq.Name}_{contactReq.Family}_{contactReq.ID.ToString()}_{contactReq.ContactType.ToString()}";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<Contacts> contacts))
            {
                // Cache miss, query the database
                contacts = await _contactManage.contacts.Where(x => (contactReq.Name.IsNullOrEmpty() ? 1 == 1 : contactReq.Name == x.Name) &&
                       (contactReq.Family.IsNullOrEmpty() ? 1 == 1 : contactReq.Family == x.Family) &&
                       (contactReq.PhoneNumber.IsNullOrEmpty() ? 1 == 1 : contactReq.PhoneNumber == x.Mobile) &&
                       (contactReq.Address.IsNullOrEmpty() ? 1 == 1 : x.Address.Equals(contactReq.Address)) &&
                       (contactReq.ContactType == null ? 1 == 1 : (int)contactReq.ContactType == x.ContactType_ID
                       )
                       ).AsNoTracking().ToListAsync();


                // Define the cache entry options
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Set the absolute expiration to one day
                .SetAbsoluteExpiration(TimeSpan.FromDays(1))
                // Set the size of the cache entry
                .SetSize(1);

                // Set the query result in the cache
                _cache.Set(cacheKey, contacts, cacheEntryOptions);
            }
            return new List<Contacts>(contacts);
        }


        public async Task<Contacts> UpdateContact(ContactReq contactReq)
        {
            if (contactReq.ID == null)
            {
                _logger.LogError("ContactID Empty");
                GeneralExtention.ThrowException("ContactID Empty", ContactManageEntities.Enum.HttpStatus.NotFound);
            }
            var result = await _contactManage.contacts.Where(x => x.Id == contactReq.ID).FirstOrDefaultAsync();
            if (result == null)
            {

                _logger.LogError("Contact Not Found");
                GeneralExtention.ThrowException("Contact Not Found", ContactManageEntities.Enum.HttpStatus.NotFound);
            }
            if (!contactReq.Family.IsNullOrEmpty())
                result.Family = contactReq.Family;
            if (!contactReq.Name.IsNullOrEmpty())
                result.Name = contactReq.Name;
            if (!contactReq.PhoneNumber.IsNullOrEmpty())
                result.Mobile = contactReq.PhoneNumber;
            if (!contactReq.Address.IsNullOrEmpty())
                result.Address = contactReq.Address;
            if (contactReq.ContactType != null)
                result.ContactType_ID = (int)contactReq.ContactType;

            _contactManage.contacts.Update(result);
           await _contactManage.SaveChangesAsync();
            return result;

        }
        public async Task DeleteContact(int contactId)
        {
            var result = await _contactManage.contacts.Where(_x => _x.Id == contactId).FirstOrDefaultAsync();
            if (result == null)
            { 
            _logger.LogError("Contact Not Found");
                GeneralExtention.ThrowException("Contact Not Found", HttpStatus.BadRequest);
        }
                _contactManage.contacts.Remove(result); 
            await _contactManage.SaveChangesAsync();
  
        }
    }
}
