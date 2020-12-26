namespace exclucv.Errors.ResponseErrors
{
    using System.Net;

    public class AbortedLoginError : ApiError
    {
        public AbortedLoginError(string message, bool succeeded)
            : base(406, HttpStatusCode.NotAcceptable.ToString(), message, succeeded)
        {
        }
    }
}
