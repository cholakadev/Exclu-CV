namespace exclucv.Core.DomainModel
{
    using System;

    public class Education
    {
        public string Institution { get; set; }

        public string Class { get; set; }

        public string Degree { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? GraduationDate { get; set; }
    }
}
