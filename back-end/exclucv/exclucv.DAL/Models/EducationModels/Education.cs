namespace exclucv.DAL.Models.EducationModels
{
    using Newtonsoft.Json;
    using System;

    public class Education
    {
        public int Id { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("institution")]
        public string Institution { get; set; }

        [JsonProperty("course")]
        public string Course { get; set; }

        //public int CvModelId { get; set; }

        //public CvModel CV { get; set; }
    }
}
