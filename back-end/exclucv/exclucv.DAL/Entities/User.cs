using System;
using System.Collections.Generic;

namespace exclucv.DAL.Entities
{
    public partial class User
    {
        public User()
        {
            Template = new HashSet<Template>();
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Template> Template { get; set; }
    }
}
