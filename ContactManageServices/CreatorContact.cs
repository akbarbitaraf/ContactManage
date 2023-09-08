using ContactManageRepositories;
using ContactManageServices.Interfaces;
using ContactManageServices.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactManageServices
{
    public class CreatorContact : ICreatorContact
    {
        private readonly ContactManageContext _contactManage;
        private readonly ILogger<EssentialContacts> _loggerEssentialContacts;
        private readonly ILogger<NormalContacts> _loggerNormalContacts;
        private readonly ILogger<ReliefContacts> _loggerReliefContacts;
        private readonly ILogger<GlobalContacts> _loggerGlobalContacts;


        public CreatorContact(ContactManageContext contactManage, ILogger<EssentialContacts> loggerEssentialContacts, ILogger<NormalContacts> loggerNormalContacts , ILogger<ReliefContacts> loggerReliefContacts
            , ILogger<GlobalContacts> loggerGlobalContacts
            )
        {
            _contactManage = contactManage;
            _loggerEssentialContacts = loggerEssentialContacts;
            _loggerNormalContacts = loggerNormalContacts;
            _loggerReliefContacts = loggerReliefContacts;
            _loggerGlobalContacts = loggerGlobalContacts;

        }
        public IContact CreatorConstructor(int type)
        {
            switch (type)
            {
                case 0: return new EssentialContacts(_contactManage , _loggerEssentialContacts);
                case 1: return new NormalContacts(_contactManage , _loggerNormalContacts);
                case 2: return new ReliefContacts(_contactManage , _loggerReliefContacts);
                default: return new GlobalContacts(_contactManage, _loggerGlobalContacts);

            }
        }
    }
}
