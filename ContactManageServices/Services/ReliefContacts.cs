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
    public class ReliefContacts : IContact
    {
        private readonly ContactManageContext _contactManage;
        private readonly ILogger<ReliefContacts> _logger; 
        public ReliefContacts(ContactManageContext contactManage, ILogger<ReliefContacts> logger)
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

    
        public Task<ContactRes> DeleteContact(int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<Contacts> GetContact(int contactId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Contacts>> GetContacts()
        {
            return await _contactManage.contacts.AsNoTracking().ToListAsync(); 
        }

        public Task<ContactRes> UpdateContact(Contacts contactReq)
        {
            throw new NotImplementedException();
        }
    }
}
