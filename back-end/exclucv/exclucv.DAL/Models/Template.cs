using System;
using System.Collections.Generic;

namespace exclucv.Data.Models
{
    public partial class Template
    {
        public Template()
        {
            Education = new HashSet<Education>();
            Experience = new HashSet<Experience>();
            Skill = new HashSet<Skill>();
        }

        public Guid Id { get; set; }
        public string Summary { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Education> Education { get; set; }
        public virtual ICollection<Experience> Experience { get; set; }
        public virtual ICollection<Skill> Skill { get; set; }
    }
}
