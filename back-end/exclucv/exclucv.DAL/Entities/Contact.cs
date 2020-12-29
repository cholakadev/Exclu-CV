using System;
using System.Collections.Generic;

namespace exclucv.DAL.Entities
{
    public partial class Contact
    {
        public Guid ContactId { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public Guid? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
