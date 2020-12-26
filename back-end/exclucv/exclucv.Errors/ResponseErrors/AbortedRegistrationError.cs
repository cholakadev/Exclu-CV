namespace exclucv.Errors.ResponseErrors
{
    using System.Net;

    public class AbortedRegistrationError : ApiError
    {
        public AbortedRegistrationError(string message)
            : base(406, HttpStatusCode.NotAcceptable.ToString(), message)
        {
        }
    }
}
