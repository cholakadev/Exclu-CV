namespace exclucv.DAL.Models.MainInfo
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class MainInformation
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(20)]
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonProperty("position")]
        public string Position { get; set; }

        [Required]
        [JsonProperty("department")]
        public string Department { get; set; }

        [Required]
        [JsonProperty("level")]
        public string Level { get; set; }

        [Required]
        [MaxLength(100)]
        [JsonProperty("location")]
        public string Location { get; set; }

        [Required]
        [MaxLength(2500)]
        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
}
