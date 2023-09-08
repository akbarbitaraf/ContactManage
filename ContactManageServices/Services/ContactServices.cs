using AutoMapper;
using ContactManageEntities.DB;
using ContactManageEntities.DTO.Record;
using ContactManageEntities.Enum;
using ContactManageServices.Interfaces;
using ContactManageTools;
using Microsoft.Extensions.Logging;
namespace ContactManageServices.Services
{
    public class ContactServices
    {
       
        private readonly ILogger<ContactServices> _logger;
        private readonly ICreatorContact _creatorContact;
        private readonly IMapper _mapper;

        public ContactServices(ICreatorContact creatorContact, IMapper mapper, ILogger<ContactServices> logger)
        {
            _creatorContact = creatorContact;
            _mapper = mapper;
            _logger = logger;
        }
        // create Contact according contact type
        public async Task<ContactRes> CreateContact(ContactReq contactReq)
        {
            try
            {
                IContact contact = _creatorContact.CreatorConstructor(contactReq.ContactType ?? 3);
                var map = _mapper.Map<Contacts>(contactReq);
                var result = await contact.CreateContact(map);
                return new ContactRes() { ID = result.Id, Email = contactReq.Email, Address = contactReq.Address, Name = contactReq.Name, Family = contactReq.Family
                ,ContactType = contactReq.ContactType?? 3 ,PhoneNumber = contactReq.PhoneNumber
                };
            }
            // Log Error and exception to front
            catch (Exception ex)
            {
                _logger.LogError($"Fail_InsertContact:{ex.Message}", LogLevel.Error);
                GeneralExtention.ThrowException(ex.Message, HttpStatus.BadRequest);
            }
            return new ContactRes();
        }
        public async Task<ContactRes> CreatorConstructor(ContactReq contactReq)
        {
            // contact type is  is  GLobalContact and no use contact type recieve client
            IContact contact = _creatorContact.CreatorConstructor(contactReq.ContactType ?? 3);
            var result =  await contact.GetContactsByFilter(contactReq);
            var map = _mapper.Map<ContactRes>(result);
            return map;
        }
        public async Task<List<ContactRes>> GetContacts()
        {
            IContact contact = _creatorContact.CreatorConstructor(3);
            var result  =  await contact.GetContacts();
            var listMap = _mapper.Map<List<ContactRes>>(result);
            return listMap; 
        }
        public async Task DeleteContact(int id)
        {
            IContact contact = _creatorContact.CreatorConstructor(3);
            await contact.DeleteContact(id);
        }
        public async Task<ContactRes> UpdateContact(ContactReq contactReq)
        {
            IContact contact = _creatorContact.CreatorConstructor(contactReq.ContactType);
            await contact.UpdateContact(_mapper.Map<Contacts>(contactReq));
            return new ContactRes();
        }

    }
}
