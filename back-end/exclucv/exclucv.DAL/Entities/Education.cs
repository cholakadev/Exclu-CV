using System;

namespace exclucv.DAL.Entities
{
    public partial class Education
    {
        public Guid EducationId { get; set; }
        public string Institution { get; set; }
        public string Class { get; set; }
        public string Degree { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public Guid? TemplateId { get; set; }

        public virtual Template Template { get; set; }
    }
}
