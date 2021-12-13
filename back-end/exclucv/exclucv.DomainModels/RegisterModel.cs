namespace exclucv.DomainModels.DomainModels
{
    using exclucv.DomainModel.EnumTypes;

    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
