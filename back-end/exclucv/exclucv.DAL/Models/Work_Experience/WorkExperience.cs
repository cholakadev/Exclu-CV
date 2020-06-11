namespace exclucv.DAL.Models.Work_Experience
{
    using Newtonsoft.Json;
    using System;

    public class WorkExperience
    {
        public int Id { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("project")]
        public string Project { get; set; }

        [JsonProperty("skills")]
        public string Skills { get; set; } // List<ExperienceSkill>

        //public int CvModelId { get; set; }

        //public CvModel CV { get; set; }
    }
}
