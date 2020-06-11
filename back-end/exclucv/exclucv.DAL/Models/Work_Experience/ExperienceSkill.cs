namespace exclucv.DAL.Models.Work_Experience
{
    using Newtonsoft.Json;

    public class ExperienceSkill
    {
        public int Id { get; set; }

        [JsonProperty("skill_name")]
        public string SkillName { get; set; }

        public int WorkExperienceId { get; set; }

        public WorkExperience WorkExperience { get; set; }
    }
}
