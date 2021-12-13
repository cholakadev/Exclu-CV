namespace exclucv.Core.Http
{
    using exclucv.DomainModel.EnumTypes;

    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
