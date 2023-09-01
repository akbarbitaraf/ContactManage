using AutoMapper;
using ContanctManageEntities.DB;
using ContanctManageEntities.DTO.Record;
using ContanctManageServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContanctManageServices.Services
{
    public class ContactServices
    {
        private readonly ICreatorContact _creatorContact;
        private readonly IMapper _mapper;

         public ContactServices(ICreatorContact creatorContact, IMapper mapper)
        {
            _creatorContact = creatorContact;
            _mapper = mapper;
        }
        public async Task<ContactRes> CreateContact(ContactReq contactReq)
        {
            IContact contact = _creatorContact.CreatorConstructor(contactReq.ContactType);
             await contact.CreateContact(_mapper.Map<Contacts>(contactReq));
            return new ContactRes();
        }
        public async Task<ContactRes> GetContact(int id)
        {
            IContact contact = _creatorContact.CreatorConstructor(3);
            await contact.GetContact(id);
            return new ContactRes();
        }
        public async Task<ContactRes> GetContacts()
        {
            IContact contact = _creatorContact.CreatorConstructor(3);
            await contact.GetContacts();
            return new ContactRes();
        }
        public async Task<ContactRes> DeleteContact(int id)
        {
            IContact contact = _creatorContact.CreatorConstructor(3);
            await contact.DeleteContact(id);
            return new ContactRes();
        }
        public async Task<ContactRes> UpdateContact(ContactReq contactReq)
        {
            IContact contact = _creatorContact.CreatorConstructor(contactReq.ContactType);
            await contact.UpdateContact(_mapper.Map<Contacts>(contactReq));
            return new ContactRes();
        }

    }
}
