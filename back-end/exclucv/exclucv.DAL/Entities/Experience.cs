using System;
using System.Collections.Generic;

namespace exclucv.DAL.Entities
{
    public partial class Experience
    {
        public Guid ExperienceId { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public Guid? TemplateId { get; set; }

        public virtual Template Template { get; set; }
    }
}
