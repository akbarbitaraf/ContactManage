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
                return new ContactRes()
                {
                    ID = result.Id,
                    Email = contactReq.Email,
                    Address = contactReq.Address,
                    Name = contactReq.Name,
                    Family = contactReq.Family,
                    ContactType = contactReq.ContactType ?? 3,
                    PhoneNumber = contactReq.PhoneNumber
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
        public async Task<ContactRes> GetContactByID(int contactID)
        {
            var createContactObj = _creatorContact.CreatorConstructor(3);
            var result =await createContactObj.GetContactByID(contactID);
            var map = _mapper.Map<ContactRes>(result);
            return map; 
        }
        public async Task<List<ContactRes>> GetContactsByFilter(ContactReq contactReq)
        {
         if (contactReq == null)
            {
                _logger.LogError("Neccessary Input Filtering For Search") ;
                GeneralExtention.ThrowException("فیلترهای ورودی الزامی می باشد" , HttpStatus.BadRequest);
                return new List<ContactRes>(0); 
            }
            var createContactObj = _creatorContact.CreatorConstructor(contactReq.ContactType ?? 3);
            var result = await createContactObj.GetContactsByFilter(contactReq);
            return _mapper.Map<List<ContactRes>>(result);
        }

        public async Task<List<ContactRes>> GetContacts()
        {
            _logger.LogInformation("Method GetContacts"); 
            IContact contact = _creatorContact.CreatorConstructor(3);
            var result = await contact.GetContacts();
            var listMap = _mapper.Map<List<ContactRes>>(result);
            
            return listMap;
        }
        public async Task<bool> DeleteContact(int id)
        {
            IContact contact = _creatorContact.CreatorConstructor(3);
            await contact.DeleteContact(id);
            return true;
        }
        public async Task<ContactRes> UpdateContact(ContactReq contactReq)
        {
            IContact contact = _creatorContact.CreatorConstructor(contactReq.ContactType ?? 3);
            await contact.UpdateContact(contactReq);
            var map  = _mapper.Map<ContactRes>(contact);
            return map;
        }

    }
}
