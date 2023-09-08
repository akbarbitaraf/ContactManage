﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManageEntities.DTO.Record
{
    public class ContactReq
    {
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int? ContactType { get; set; }
        public int? ID { get; set; }

    }

}
