using ContactManageEntities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManageTools
{
    public static class GeneralExtention
    {
        public static GeneralException ThrowException(string key  , HttpStatus httpStatus) { throw new GeneralException(key , httpStatus); 
        }
    }
}
