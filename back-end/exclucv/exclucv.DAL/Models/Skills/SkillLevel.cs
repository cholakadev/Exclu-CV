namespace exclucv.DAL.Models.Skills
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class SkillLevel
    {
        public int Id { get; set; }

        [Required]
        [JsonProperty("level_name")]
        public string LevelName { get; set; }
    }
}
