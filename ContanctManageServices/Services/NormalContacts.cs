using ContanctManageEntities.DB;
using ContanctManageEntities.DTO.Record;
using ContanctManageRepositories;
using ContanctManageServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContanctManageServices.Services
{
    internal class NormalContacts : IContact
    {
        private readonly ContactManageContext _contactManage;

        public NormalContacts(ContactManageContext contactManage)
        {

            _contactManage = contactManage;
        }
        public async Task<ContactRes> CreateContact(Contacts contactReq)
        {
            await _contactManage.contacts.AddAsync(contactReq);
            var result = await _contactManage.SaveChangesAsync();
            return new ContactRes();
        }

        public Task<ContactRes> DeleteContact(int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<ContactRes> GetContact(int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<ContactRes> GetContacts()
        {
            throw new NotImplementedException();
        }

        public Task<ContactRes> UpdateContact(Contacts contactReq)
        {
            throw new NotImplementedException();
        }
    }
}
