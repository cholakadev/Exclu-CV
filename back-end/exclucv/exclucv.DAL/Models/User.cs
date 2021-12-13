using System;
using System.Collections.Generic;

namespace exclucv.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Contacts = new HashSet<Contacts>();
            Template = new HashSet<Template>();
            UserTracking = new HashSet<UserTracking>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }

        public virtual ICollection<Contacts> Contacts { get; set; }
        public virtual ICollection<Template> Template { get; set; }
        public virtual ICollection<UserTracking> UserTracking { get; set; }
    }
}
