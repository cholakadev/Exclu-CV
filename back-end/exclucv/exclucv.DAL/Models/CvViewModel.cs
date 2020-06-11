namespace exclucv.DAL.Models
{
    using exclucv.DAL.Models.EducationModels;
    using exclucv.DAL.Models.MainInfo;
    using exclucv.DAL.Models.Skills;
    using exclucv.DAL.Models.Work_Experience;
    using System.Collections.Generic;

    public class CvViewModel
    {
        public int Id { get; set; }

        public string DateOfCreation { get; set; }

        public MainInformation MainInformation { get; set; }

        public List<Skill> Skill { get; set; }

        public Education Education { get; set; } // list

        public WorkExperience WorkExperience { get; set; } // list

        //public List<CertificateModel> Certificates { get; set; }
    }
}
