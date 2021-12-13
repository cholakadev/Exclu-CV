using System;
using System.Collections.Generic;

namespace exclucv.Data.Models
{
    public partial class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TemplateId { get; set; }

        public virtual Template Template { get; set; }
    }
}
