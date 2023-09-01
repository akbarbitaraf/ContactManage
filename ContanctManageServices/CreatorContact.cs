using ContanctManageRepositories;
using ContanctManageServices.Interfaces;
using ContanctManageServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContanctManageServices
{
    public class CreatorContact : ICreatorContact
    {
        private readonly ContactManageContext _contactManage;
        public CreatorContact(ContactManageContext contactManage)
        {

            _contactManage = contactManage;
        }
        public IContact CreatorConstructor(int type)
        {
            switch (type)
            {
                case 0: return new EssentialContacts(_contactManage);
                case 1: return new NormalContacts(_contactManage);
                case 2: return new ReliefContacts(_contactManage);
                default: throw new Exception();

            }
        }
    }
}
