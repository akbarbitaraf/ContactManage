using ContactManageEntities.DB;
using ContactManageEntities.DTO.Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManageServices.Interfaces
{
    public interface IContact
    {
        public Task<ContactRes> CreateContact(Contacts contactReq);
        public Task<ContactRes> UpdateContact(Contacts contactReq);
        public Task<ContactRes> DeleteContact(int contactId);
        public Task<Contacts> GetContact(int contactId);
        public Task<ContactRes> GetContacts();
    }
}
