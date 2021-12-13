using System;
using System.Collections.Generic;

namespace exclucv.Data.Models
{
    public partial class UserTracking
    {
        public Guid Id { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? RegisterDate { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
