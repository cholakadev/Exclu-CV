namespace exclucv.DAL.Models
{
    using exclucv.DAL.Models.EducationModels;
    using exclucv.DAL.Models.MainInfo;
    using exclucv.DAL.Models.Skills;
    using exclucv.DAL.Models.Work_Experience;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    [JsonObject("cv")]
    public class CvModel
    {
        private DateTime dateOfCreation;

        public int Id { get; set; }

        public string DateOfCreation { get; set; }

        public int MainInformationId { get; set; }

        [JsonProperty("main_information")]
        public MainInformation MainInformation { get; set; }

        [JsonProperty("skills")]
        public List<Skill> Skill { get; set; }

        public int EducationId { get; set; }

        [JsonProperty("educations")]
        public Education Education { get; set; } // List<Education>

        public int WorkExperienceId { get; set; }

        [JsonProperty("work_experiences")]
        public WorkExperience WorkExperience { get; set; } // List<WorkExperience>

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        //public List<CertificateModel> Certificates { get; set; }
    }
}
