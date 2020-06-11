namespace exclucv.DAL.Models.MainInfo
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class Department
    {
        public int Id { get; set; }

        [Required]
        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }
    }
}
