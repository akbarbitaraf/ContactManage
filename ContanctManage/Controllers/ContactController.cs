﻿//using Entities.DTO.Record;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Services;
//using Services.Interfaces;
//using Services.Services;
//using System.Data;

using ContanctManageServices.Services;
using ContanctManageEntities.DTO.Record;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ContanctManage.Controllersx
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ContactServices _contactServices;
        public ContactController(ContactServices contactServices)
        {
            _contactServices = contactServices; 
        }
        [HttpPost]
        public async Task<ContactRes> Creatorcontact([FromForm] ContactReq contactReq)
        {
            return await _contactServices.CreateContact(contactReq);

        }
        [HttpGet("id")]
        // برای این مورد میتون  ریکوستی دیگه ای رو هم نوشت که براساس ورودی های جستجو کرد
        public async Task<ContactRes> GetContact(int id)
        {
            return await _contactServices.GetContact(id);
        }
        [HttpGet]
        public async Task<ContactRes> GetContacts()
        {
            return await _contactServices.CreateContact(new ContactReq());
        }
        [HttpDelete]
        public async Task<ContactRes> DeleteContact(int contactId)
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        public async Task<ContactRes> UpdateContact([FromForm] ContactReq contactReq)
        {
            throw new NotImplementedException();
        }

    }
}