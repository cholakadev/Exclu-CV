using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace exclucv.DAL.Models
{
    public partial class exclucvDb_10_DevContext : DbContext
    {
        public exclucvDb_10_DevContext()
        {
        }

        public exclucvDb_10_DevContext(DbContextOptions<exclucvDb_10_DevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Experience> Experience { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserTracking> UserTracking { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=exclucvDb_10_Dev;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.MiddleName).HasMaxLength(64);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Town)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserContacts");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Degree)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.GraduationDate).HasColumnType("date");

                entity.Property(e => e.Institution)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Education)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemplateEducation");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.LeaveDate).HasColumnType("date");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Responsibility).HasMaxLength(256);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Experience)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemplateExperience");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Skill)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemplateSkill");
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Summary).HasMaxLength(1024);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Template)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTemplate");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.ProfileImage)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('Resources/Default/default.jpg')");
            });

            modelBuilder.Entity<UserTracking>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTracking)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserUserTracking");
            });
        }
    }
}
