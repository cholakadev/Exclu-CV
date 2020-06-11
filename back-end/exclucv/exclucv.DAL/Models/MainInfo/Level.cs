namespace exclucv.DAL.Models.MainInfo
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class Level
    {
        public int Id { get; set; }

        [Required]
        [JsonProperty("level_name")]
        public string LevelName { get; set; }
    }
}
