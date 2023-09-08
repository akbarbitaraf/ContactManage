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
    public class GlobalContacts : IContact
    {
        private readonly ContactManageContext _contactManage;
        private readonly ILogger<GlobalContacts> _logger;
        public GlobalContacts(ContactManageContext contactManage, ILogger<GlobalContacts> logger)
        {

            _contactManage = contactManage;
            _logger = logger;
        }
        public async Task<Contacts> CreateContact(Contacts contactReq)
        {
            await _contactManage.contacts.AddAsync(contactReq);
            var result = await _contactManage.SaveChangesAsync();
            contactReq.Id = result;
            return contactReq;
        }
        public Task DeleteContact(int contactId)
        {
            throw new NotImplementedException();
        }
        public async Task<Contacts> GetContact(int contactId)
        {
            return await _contactManage.contacts.Where(x => x.Id == contactId).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<List<Contacts>> GetContacts()
        {
            throw new NotImplementedException();

        }
        public Task<ContactRes> UpdateContact(Contacts contactReq)
        {
            throw new NotImplementedException();
        }
    }
}