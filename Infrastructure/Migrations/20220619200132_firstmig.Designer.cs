﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220619200132_firstmig")]
    partial class firstmig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Entities.Candidates.Experience", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CandidatId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("duration")
                        .HasColumnType("int");

                    b.Property<int>("tech")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidatId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("DAL.Entities.JobOffer.JobOffer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AvailablePlaces")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmployerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmployerId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("JobOfferTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Remote")
                        .HasColumnType("bit");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Technologies")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId1");

                    b.ToTable("JobOffer");
                });

            modelBuilder.Entity("DAL.Entities.JobOffer.Postulation", b =>
                {
                    b.Property<string>("JobOfferId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CandidId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("ResumePost")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobOfferId", "CandidId");

                    b.HasIndex("CandidId");

                    b.ToTable("Postulations");
                });

            modelBuilder.Entity("DAL.Entities.Questions.Domain", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Domain");
                });

            modelBuilder.Entity("DAL.Entities.Questions.QcmResponse", b =>
                {
                    b.Property<string>("QcmQuestionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isTrue")
                        .HasColumnType("bit");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("QcmQuestionId");

                    b.ToTable("QcmResponses");
                });

            modelBuilder.Entity("DAL.Entities.Questions.Question", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("TestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("difficulty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("domainId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("domain_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("duration")
                        .HasColumnType("int");

                    b.Property<Guid>("employer_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("score")
                        .HasColumnType("real");

                    b.Property<string>("tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("typeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.HasIndex("domainId");

                    b.HasIndex("typeId");

                    b.ToTable("Questions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Question");
                });

            modelBuilder.Entity("DAL.Entities.Questions.QuestType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("QuestType");
                });

            modelBuilder.Entity("DAL.Entities.Reponse.Choice", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("choice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isTrue")
                        .HasColumnType("bit");

                    b.Property<string>("questionId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("questionId");

                    b.ToTable("Choice");
                });

            modelBuilder.Entity("DAL.Entities.Test.Test", b =>
                {
                    b.Property<Guid>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("candidatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("employerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("employerId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestId");

                    b.HasIndex("employerId1");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHashed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Phone_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Profile_image")
                        .HasColumnType("tinyint");

                    b.Property<byte[]>("ResumeUser")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Candidates.Candidat", b =>
                {
                    b.HasBaseType("DAL.Entities.User");

                    b.HasDiscriminator().HasValue("Candidat");
                });

            modelBuilder.Entity("DAL.Entities.Employer", b =>
                {
                    b.HasBaseType("DAL.Entities.User");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyWebsite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Employer");
                });

            modelBuilder.Entity("DAL.Entities.Questions.QcmQuestion", b =>
                {
                    b.HasBaseType("DAL.Entities.Questions.Question");

                    b.Property<int>("priority")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("QcmQuestion");
                });

            modelBuilder.Entity("DAL.Entities.Candidates.Experience", b =>
                {
                    b.HasOne("DAL.Entities.Candidates.Candidat", null)
                        .WithMany("experiences")
                        .HasForeignKey("CandidatId");
                });

            modelBuilder.Entity("DAL.Entities.JobOffer.JobOffer", b =>
                {
                    b.HasOne("DAL.Entities.Employer", "Employer")
                        .WithMany()
                        .HasForeignKey("EmployerId1");

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("DAL.Entities.JobOffer.Postulation", b =>
                {
                    b.HasOne("DAL.Entities.Candidates.Candidat", "Candidat")
                        .WithMany("Postulations")
                        .HasForeignKey("CandidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.JobOffer.JobOffer", "JobOffer")
                        .WithMany("Postulations")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidat");

                    b.Navigation("JobOffer");
                });

            modelBuilder.Entity("DAL.Entities.Questions.QcmResponse", b =>
                {
                    b.HasOne("DAL.Entities.Questions.QcmQuestion", null)
                        .WithMany()
                        .HasForeignKey("QcmQuestionId");
                });

            modelBuilder.Entity("DAL.Entities.Questions.Question", b =>
                {
                    b.HasOne("DAL.Entities.Test.Test", null)
                        .WithMany("questions")
                        .HasForeignKey("TestId");

                    b.HasOne("DAL.Entities.Questions.Domain", "domain")
                        .WithMany()
                        .HasForeignKey("domainId");

                    b.HasOne("DAL.Entities.Questions.QuestType", "type")
                        .WithMany()
                        .HasForeignKey("typeId");

                    b.Navigation("domain");

                    b.Navigation("type");
                });

            modelBuilder.Entity("DAL.Entities.Reponse.Choice", b =>
                {
                    b.HasOne("DAL.Entities.Questions.Question", "question")
                        .WithMany()
                        .HasForeignKey("questionId");

                    b.Navigation("question");
                });

            modelBuilder.Entity("DAL.Entities.Test.Test", b =>
                {
                    b.HasOne("DAL.Entities.Employer", "employer")
                        .WithMany()
                        .HasForeignKey("employerId1");

                    b.Navigation("employer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.JobOffer.JobOffer", b =>
                {
                    b.Navigation("Postulations");
                });

            modelBuilder.Entity("DAL.Entities.Test.Test", b =>
                {
                    b.Navigation("questions");
                });

            modelBuilder.Entity("DAL.Entities.Candidates.Candidat", b =>
                {
                    b.Navigation("Postulations");

                    b.Navigation("experiences");
                });
#pragma warning restore 612, 618
        }
    }
}