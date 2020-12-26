namespace exclucv.Errors.ResponseErrors
{
    using Newtonsoft.Json;

    public class ApiError
    {
        public int StatusCode { get; private set; }

        public string StatusDescription { get; private set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Message { get; private set; }

        public bool Succeeded { get; private set; }

        public ApiError(int statusCode, string statusDescription)
        {
            this.StatusCode = statusCode;
            this.StatusDescription = statusDescription;
        }

        public ApiError(int statusCode, string statusDescription, string message, bool succeeded)
            : this(statusCode, statusDescription)
        {
            this.Message = message;
            this.Succeeded = succeeded;
        }
    }
}
