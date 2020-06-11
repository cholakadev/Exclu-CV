namespace exclucv.DAL.Models
{
    using exclucv.DAL.Models.EducationModels;
    using exclucv.DAL.Models.MainInfo;
    using exclucv.DAL.Models.Skills;
    using exclucv.DAL.Models.Work_Experience;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ExclucvDbContext : IdentityDbContext<ApplicationUser>
    {
        public ExclucvDbContext(DbContextOptions<ExclucvDbContext> options)
            : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<CvModel> CVs { get; set; }

        public DbSet<MainInformation> MainInformation { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Education> Education { get; set; }

        public DbSet<WorkExperience> WorkExperience { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Level> Levels { get; set; }

        public DbSet<SkillLevel> SkillLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<CvModel>().HasOne(e => e.ApplicationUser).WithMany(e => e.Cvs).HasForeignKey(e => e.ApplicationUserId);
        }
    }
}
