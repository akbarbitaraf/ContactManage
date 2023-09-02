using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManageEntities.Enum
{
    public enum HttpStatus
    {
        OK = 200,
        NotFound = 404,
        BadRequest = 400,
        Conflict = 409,
        Unauthorized = 401,
        Forbidden = 403
    }
}
