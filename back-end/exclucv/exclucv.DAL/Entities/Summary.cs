using System;
using System.Collections.Generic;

namespace exclucv.DAL.Entities
{
    public partial class Summary
    {
        public Summary()
        {
            Template = new HashSet<Template>();
        }

        public Guid SummaryId { get; set; }
        public string Summary1 { get; set; }

        public virtual ICollection<Template> Template { get; set; }
    }
}
