using System;
using System.Collections.Generic;

namespace exclucv.DAL.Entities
{
    public partial class Template
    {
        public Template()
        {
            Education = new HashSet<Education>();
            Experience = new HashSet<Experience>();
            Skill = new HashSet<Skill>();
        }

        public Guid TemplateId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? SummaryId { get; set; }

        public virtual Summary Summary { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Education> Education { get; set; }
        public virtual ICollection<Experience> Experience { get; set; }
        public virtual ICollection<Skill> Skill { get; set; }
    }
}
