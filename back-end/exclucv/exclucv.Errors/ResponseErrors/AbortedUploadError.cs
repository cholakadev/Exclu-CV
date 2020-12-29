namespace exclucv.Errors.ResponseErrors
{
    using System.Net;

    public class AbortedUploadError : ApiError
    {
        public AbortedUploadError(string message, bool succeeded)
            : base(406, HttpStatusCode.NotAcceptable.ToString(), message, succeeded)
        {
        }
    }
}
