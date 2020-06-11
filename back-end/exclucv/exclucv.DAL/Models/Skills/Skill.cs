namespace exclucv.DAL.Models.Skills
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class Skill
    {
        public int Id { get; set; }

        [Required]
        [JsonProperty("skill_name")]
        public string SkillName { get; set; }

        [JsonProperty("skill_level")]
        public string SkillLevel { get; set; }

        public int CvModelId { get; set; }

        public CvModel CvModel { get; set; }
    }
}
