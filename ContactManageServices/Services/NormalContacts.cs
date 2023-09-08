using ContactManageEntities.DB;
using ContactManageEntities.DTO.Record;
using ContactManageRepositories;
using ContactManageServices.Interfaces;
using ContactManageTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManageServices.Services
{
    public class NormalContacts : IContact
    {
        private readonly ContactManageContext _contactManage;
        private readonly ILogger<NormalContacts> _logger;


        public NormalContacts(ContactManageContext contactManage, ILogger<NormalContacts> logger)
        {

            _contactManage = contactManage;
            _logger = logger;
        }
        public async Task<Contacts> CreateContact(Contacts contactReq)
        {
            await _contactManage.contacts.AddAsync(contactReq);
            var result = await _contactManage.SaveChangesAsync();
            contactReq.Id = result;
            return contactReq;
        }


        public Task DeleteContact(int contactId)
        {
            throw new NotImplementedException();
        }


        public async Task<Contacts> GetContactByID(int contactID)
        {
            return await _contactManage.contacts.Where(x => x.Id == contactID).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<Contacts>> GetContacts()
        {
            return await _contactManage.contacts.AsNoTracking().ToListAsync();
        }

        public async Task<List<Contacts>> GetContactsByFilter(ContactReq contactReq)
        {
            var result = await _contactManage.contacts.Where(x => (contactReq.Name.IsNullOrEmpty() ? 1 == 1 : contactReq.Name == x.Name) &&
                       (contactReq.Family.IsNullOrEmpty() ? 1 == 1 : contactReq.Family == x.Family) &&
                       (contactReq.PhoneNumber.IsNullOrEmpty() ? 1 == 1 : contactReq.PhoneNumber == x.Mobile) &&
                       (contactReq.Address.IsNullOrEmpty() ? 1 == 1 : x.Address.Equals(contactReq.Address)) &&
                       (contactReq.ContactType == null ? 1 == 1 : (int)contactReq.ContactType == x.ContactType_ID
                       )
                       ).AsNoTracking().ToListAsync();
            return result;
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
    }
}
