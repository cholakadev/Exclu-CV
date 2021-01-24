using Newtonsoft.Json;
using System;

namespace exclucv.DAL.Entities
{
    public partial class Education
    {
        public Guid EducationId { get; set; }
        [JsonProperty("institution")]
        public string Institution { get; set; }
        [JsonProperty("class")]
        public string Class { get; set; }
        [JsonProperty("degree")]
        public string Degree { get; set; }
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }
        [JsonProperty("end_date")]
        public DateTime? EndDate { get; set; }
        [JsonProperty("is_active")]
        public bool? IsActive { get; set; }
        public Guid? TemplateId { get; set; }

        public virtual Template Template { get; set; }
    }
}
