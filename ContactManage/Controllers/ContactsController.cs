using Microsoft.AspNetCore.Mvc;
using ContactManageServices.Services;
using ContactManageEntities.DTO.Record;

namespace ContactManage.Controllersx
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactServices _contactServices;
        public ContactsController(ContactServices contactServices)
        {
            _contactServices = contactServices; 
        }
        [HttpPost]
        // Create Contact 
        public async Task<ContactRes> Creatorcontact([FromForm] ContactReq contactReq)
        {
            return await _contactServices.CreateContact(contactReq);

        }
        // Get Contact By Contact ID 
        [HttpGet("id")]
        public async Task<ContactRes> GetContactByID(int id)
        {
            return await _contactServices.GetContactByID(id);
        }
        [HttpGet]
        public async Task<List<ContactRes>> GetContacts()
        {
            return await _contactServices.GetContacts();
        }
        [HttpPost("ContactsByFilter")]
        public async Task<List<ContactRes>> GetContactsByFilter([FromBody] ContactReq contactReq)
        {
            return await _contactServices.GetContactsByFilter(contactReq);
        }
        [HttpDelete]
        public async Task<bool> DeleteContact(int contactId)
        {
            await _contactServices.DeleteContact(contactId);
            return true;
        }
        [HttpPut]
        public async Task<ContactRes> UpdateContact([FromForm] ContactReq contactReq)
        {
            return await _contactServices.UpdateContact(contactReq);
        }

    }
}
