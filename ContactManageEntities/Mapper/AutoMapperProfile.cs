using AutoMapper;
using ContactManageEntities.DB;
using ContactManageEntities.DTO.Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContactManageEntities.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ContactReq, Contacts>()
                .ForMember(x => x.Address, a => a.MapFrom(y => y.Address))
                .ForMember(x => x.Email, a => a.MapFrom(y => y.Email))
                .ForMember(x => x.Mobile, a => a.MapFrom(y => y.PhoneNumber))
                .ForMember(x => x.Name, a => a.MapFrom(y => y.Name))
                .ForMember(x => x.Family, a => a.MapFrom(y => y.Family))
                .ForMember(x => x.ContactType_ID, a => a.MapFrom(y => y.ContactType));

            CreateMap<Contacts, ContactRes>()
                 .ForMember(x => x.Address, a => a.MapFrom(y => y.Address))
                 .ForMember(x => x.Email, a => a.MapFrom(y => y.Email))
                 .ForMember(x => x.PhoneNumber, a => a.MapFrom(y => y.Mobile))
                 .ForMember(x => x.Name, a => a.MapFrom(y => y.Name))
                 .ForMember(x => x.Family, a => a.MapFrom(y => y.Family));               


        }
    }
}
