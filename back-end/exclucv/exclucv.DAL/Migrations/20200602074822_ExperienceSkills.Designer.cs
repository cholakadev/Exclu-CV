﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using exclucv.DAL.Models;

namespace exclucv.DAL.Migrations
{
    [DbContext(typeof(ExclucvDbContext))]
    [Migration("20200602074822_ExperienceSkills")]
    partial class ExperienceSkills
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("exclucv.DAL.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("exclucv.DAL.Models.CvModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime>("DateOfCreation");

                    b.Property<int>("EducationId");

                    b.Property<int>("MainInformationId");

                    b.Property<int>("WorkExperienceId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("EducationId");

                    b.HasIndex("MainInformationId");

                    b.HasIndex("WorkExperienceId");

                    b.ToTable("CVs");
                });

            modelBuilder.Entity("exclucv.DAL.Models.EducationModels.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Course");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Institution");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("exclucv.DAL.Models.MainInfo.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("exclucv.DAL.Models.MainInfo.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LevelName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("exclucv.DAL.Models.MainInfo.MainInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department")
                        .IsRequired();

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Level")
                        .IsRequired();

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(2500);

                    b.HasKey("Id");

                    b.ToTable("MainInformation");
                });

            modelBuilder.Entity("exclucv.DAL.Models.Skills.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CvModelId");

                    b.Property<string>("SkillLevel");

                    b.Property<string>("SkillName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CvModelId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("exclucv.DAL.Models.Skills.SkillLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LevelName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("SkillLevels");
                });

            modelBuilder.Entity("exclucv.DAL.Models.Work_Experience.WorkExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Position");

                    b.Property<string>("Project");

                    b.Property<string>("Skills");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("WorkExperience");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("exclucv.DAL.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("exclucv.DAL.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("exclucv.DAL.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("exclucv.DAL.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("exclucv.DAL.Models.CvModel", b =>
                {
                    b.HasOne("exclucv.DAL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Cvs")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("exclucv.DAL.Models.EducationModels.Education", "Education")
                        .WithMany()
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("exclucv.DAL.Models.MainInfo.MainInformation", "MainInformation")
                        .WithMany()
                        .HasForeignKey("MainInformationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("exclucv.DAL.Models.Work_Experience.WorkExperience", "WorkExperience")
                        .WithMany()
                        .HasForeignKey("WorkExperienceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("exclucv.DAL.Models.Skills.Skill", b =>
                {
                    b.HasOne("exclucv.DAL.Models.CvModel", "CvModel")
                        .WithMany("Skill")
                        .HasForeignKey("CvModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}