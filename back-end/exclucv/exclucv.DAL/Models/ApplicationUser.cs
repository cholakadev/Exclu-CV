namespace exclucv.DAL.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser
    {
        public List<CvModel> Cvs { get; set; }

        public string ProfileImage { get; set; }
    }
}
