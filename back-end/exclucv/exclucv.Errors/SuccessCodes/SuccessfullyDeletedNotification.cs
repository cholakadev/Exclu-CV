namespace exclucv.Errors.SuccessCodes
{
    public class SuccessfullyDeletedNotification : ApiSuccess
    {
        public SuccessfullyDeletedNotification(string statusDescription)
            : base(statusDescription)
        {
        }
    }
}
