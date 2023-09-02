using AutoMapper;
using ContactManageEntities.DB;
using ContactManageEntities.DTO.Record;
using ContactManageServices.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManageServices.Services
{
    public class ContactServices
    {
        private readonly ILogger<ContactServices> _logger;
        private readonly ICreatorContact _creatorContact;
        private readonly IMapper _mapper;

         public ContactServices(ICreatorContact creatorContact, IMapper mapper , ILogger<ContactServices> logger)
        {
            _creatorContact = creatorContact;
            _mapper = mapper;
          _logger = logger;
        }
        public async Task<ContactRes> CreateContact(ContactReq contactReq)
        {
            try
            {
                IContact contact = _creatorContact.CreatorConstructor(contactReq.ContactType);
                var map =  _mapper.Map<Contacts>(contactReq);
               var result  =  await contact.CreateContact(map);
                return new ContactRes() { ID = result.ID , Email = contactReq.Email , Address = contactReq.Address , Name = contactReq.Name , Family = contactReq.Family };

            }
            catch (Exception ex)
            {

                _logger.LogError($"Fail_InsertContact:{ex.Message}", LogLevel.Error);
            }
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
