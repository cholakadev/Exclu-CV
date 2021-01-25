namespace exclucv.Errors.SuccessCodes
{
    public class ApiSuccess
    {
        public ApiSuccess(string statusDescription)
        {
            this.StatusCode = 200;
            this.StatusDescription = statusDescription;
        }

        public int StatusCode { get; private set; }

        public string StatusDescription { get; private set; }
    }
}
