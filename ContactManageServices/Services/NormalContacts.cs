﻿using ContactManageEntities.DB;
using ContactManageEntities.DTO.Record;
using ContactManageRepositories;
using ContactManageServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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


        public NormalContacts(ContactManageContext contactManage , ILogger<NormalContacts> logger)
        {

            _contactManage = contactManage;
            _logger = logger;
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

        public async Task<Contacts> GetContact(int contactId)
        {
          return  await _contactManage.contacts.Where(x => x.Id == contactId).AsNoTracking().FirstOrDefaultAsync();
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