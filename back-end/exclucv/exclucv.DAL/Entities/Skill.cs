using System;

namespace exclucv.DAL.Entities
{
    public partial class Skill
    {
        public Guid SkillId { get; set; }
        public string Skill1 { get; set; }
        public Guid? TemplateId { get; set; }

        public virtual Template Template { get; set; }
    }
}
