using System;

namespace exclucv.DomainModels.DomainModels
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
    }
}
