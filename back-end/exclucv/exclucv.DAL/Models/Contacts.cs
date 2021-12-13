using System;
using System.Collections.Generic;

namespace exclucv.DAL.Models
{
    public partial class Contacts
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public string PostalCode { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
