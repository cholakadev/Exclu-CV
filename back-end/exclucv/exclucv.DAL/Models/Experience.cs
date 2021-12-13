using System;
using System.Collections.Generic;

namespace exclucv.Data.Models
{
    public partial class Experience
    {
        public Guid Id { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string Responsibility { get; set; }
        public Guid TemplateId { get; set; }

        public virtual Template Template { get; set; }
    }
}
