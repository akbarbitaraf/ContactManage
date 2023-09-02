
using ContactManageEntities.Enum;

namespace ContactManageTools
{
    public class GeneralException : Exception
    {
        public HttpStatus status;
        public string message;

        public GeneralException(string message, HttpStatus httpStatus)
        {
            this.message = message;
            this.status = httpStatus;
        }

    }
}