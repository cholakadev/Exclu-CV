namespace exclucv.DomainModels.DomainModels
{
    using System;

    public class EducationModel
    {
        public string Institution { get; set; }

        public string Class { get; set; }

        public string Degree { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? IsActive { get; set; }
    }
}
