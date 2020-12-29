using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace exclucv.DAL.Entities
{
    public partial class exclucv_dbContext : DbContext
    {
        public exclucv_dbContext()
        {
        }

        public exclucv_dbContext(DbContextOptions<exclucv_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Experience> Experience { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Summary> Summary { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GIAS8II\\SQLEXPRESS;Database=exclucv_db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactId).ValueGeneratedNever();

                entity.Property(e => e.Country).HasMaxLength(64);

                entity.Property(e => e.PostalCode).HasMaxLength(32);

                entity.Property(e => e.Town).HasMaxLength(64);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Contact__UserId__6FE99F9F");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.Property(e => e.EducationId).ValueGeneratedNever();

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Degree)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Institution)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Education)
                    .HasForeignKey(d => d.TemplateId)
                    .HasConstraintName("FK__Education__Templ__3F466844");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.Property(e => e.ExperienceId).ValueGeneratedNever();

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Experience)
                    .HasForeignKey(d => d.TemplateId)
                    .HasConstraintName("FK__Experienc__Templ__45F365D3");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillId).ValueGeneratedNever();

                entity.Property(e => e.Skill1)
                    .IsRequired()
                    .HasColumnName("Skill")
                    .HasMaxLength(64);

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Skill)
                    .HasForeignKey(d => d.TemplateId)
                    .HasConstraintName("FK__Skill__TemplateI__4222D4EF");
            });

            modelBuilder.Entity<Summary>(entity =>
            {
                entity.Property(e => e.SummaryId).ValueGeneratedNever();

                entity.Property(e => e.Summary1)
                    .IsRequired()
                    .HasColumnName("Summary")
                    .HasMaxLength(1024);
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.Property(e => e.TemplateId).ValueGeneratedNever();

                entity.HasOne(d => d.Summary)
                    .WithMany(p => p.Template)
                    .HasForeignKey(d => d.SummaryId)
                    .HasConstraintName("FK__Template__Summar__3B75D760");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Template)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Template__UserId__3A81B327");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.FirstName).HasMaxLength(64);

                entity.Property(e => e.LastName).HasMaxLength(64);

                entity.Property(e => e.MiddleName).HasMaxLength(64);

                entity.Property(e => e.MobileNumber).HasMaxLength(64);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.ProfileImage)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('Resources/Default/default.jpg')");
            });
        }
    }
}
