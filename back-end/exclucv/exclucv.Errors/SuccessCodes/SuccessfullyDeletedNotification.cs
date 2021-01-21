using exclucv.Errors.ResponseErrors;
using System.Net;

namespace exclucv.Errors.SuccessCodes
{
    public class SuccessfullyDeletedNotification : ApiError
    {
        public SuccessfullyDeletedNotification(string message, bool succeeded)
            : base(200, HttpStatusCode.NotAcceptable.ToString(), message, succeeded)
        {
        }
    }
}
