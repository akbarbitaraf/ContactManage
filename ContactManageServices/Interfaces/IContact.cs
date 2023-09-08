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
        public Task<Contacts> CreateContact(Contacts contactReq);
        public Task<Contacts> UpdateContact(ContactReq contactReq);
        public Task DeleteContact(int contactId);
        public Task<List<Contacts>> GetContactsByFilter(ContactReq contactReq);
        public Task<List<Contacts>> GetContacts();
        public Task<Contacts> GetContactByID(int contactID);

    }
}
