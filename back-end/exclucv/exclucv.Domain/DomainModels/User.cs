namespace exclucv.DomainModel
{
    using System;

    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public string ProfileImage { get; set; }
    }
}
