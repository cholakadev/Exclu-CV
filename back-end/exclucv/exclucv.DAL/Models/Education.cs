using System;
using System.Collections.Generic;

namespace exclucv.DAL.Models
{
    public partial class Education
    {
        public Guid Id { get; set; }
        public string Institution { get; set; }
        public string Class { get; set; }
        public string Degree { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? GraduationDate { get; set; }
        public Guid TemplateId { get; set; }

        public virtual Template Template { get; set; }
    }
}
