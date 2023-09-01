using AutoMapper;
using ContanctManageEntities.DB;
using ContanctManageEntities.DTO.Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContanctManageEntities.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Contacts, ContactReq>()
                .ForMember(x => x.Address, a => a.MapFrom(y => y.Address))
                .ForMember(x => x.Email, a => a.MapFrom(y => y.Email))
                .ForMember(x => x.PhoneNumber, a => a.MapFrom(y => y.Phone))
                .ForMember(x => x.Name, a => a.MapFrom(y => y.Name))
                .ForMember(x => x.Family, a => a.MapFrom(y => y.Family))
                .ForMember(x => x.ContactType, a => a.MapFrom(y => y.ContactType_ID));

            CreateMap<ContactRes, Contacts>()
                 .ForMember(x => x.Address, a => a.MapFrom(y => y.Address))
                 .ForMember(x => x.Email, a => a.MapFrom(y => y.Email))
                 .ForMember(x => x.Phone, a => a.MapFrom(y => y.PhoneNumber))
                 .ForMember(x => x.Name, a => a.MapFrom(y => y.Name))
                 .ForMember(x => x.Family, a => a.MapFrom(y => y.Family))
                 .ForMember(x => x.ContactType_ID, a => a.MapFrom(y => y.ContactType));

        }
    }
}
