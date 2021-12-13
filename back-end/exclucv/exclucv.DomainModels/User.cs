using System;

namespace exclucv.DomainModels.DomainModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
    }
}
