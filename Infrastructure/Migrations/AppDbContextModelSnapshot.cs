﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Entities.Candidat.Experience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("duration")
                        .HasColumnType("int");

                    b.Property<int?>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("DAL.Entities.Candidat.Technologie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CandidatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ExperienceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("field")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidatId");

                    b.HasIndex("ExperienceId");

                    b.ToTable("Technologie");
                });

            modelBuilder.Entity("DAL.Entities.Questions.Domain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<int?>("status")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Domain");
                });

            modelBuilder.Entity("DAL.Entities.Questions.QcmResponse", b =>
                {
                    b.Property<Guid?>("QcmQuestionId")
                        .HasColumnType("uniqueidentifier");

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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("difficulty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("domainId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("domain_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("duration")
                        .HasColumnType("int");

                    b.Property<Guid>("employer_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("score")
                        .HasColumnType("real");

                    b.Property<int?>("status")
                        .HasColumnType("int");

                    b.Property<string>("tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("typeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.HasIndex("domainId");

                    b.HasIndex("typeId");

                    b.ToTable("Questions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Question");
                });

            modelBuilder.Entity("DAL.Entities.Questions.QuestType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<int?>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("QuestType");
                });

            modelBuilder.Entity("DAL.Entities.Reponse.Choice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("choice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isTrue")
                        .HasColumnType("bit");

                    b.Property<Guid?>("questionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("status")
                        .HasColumnType("int");

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

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestId");

                    b.HasIndex("employerId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<string>("companyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyWebsite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passwordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("profile_image")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("resume")
                        .HasColumnType("tinyint");

                    b.Property<int?>("status")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("DAL.Entities.Candidat.Candidat", b =>
                {
                    b.HasBaseType("DAL.Entities.User");

                    b.Property<int>("test")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Candidat");
                });

            modelBuilder.Entity("DAL.Entities.Employer", b =>
                {
                    b.HasBaseType("DAL.Entities.User");

                    b.HasDiscriminator().HasValue("Employer");
                });

            modelBuilder.Entity("DAL.Entities.Questions.QcmQuestion", b =>
                {
                    b.HasBaseType("DAL.Entities.Questions.Question");

                    b.Property<int>("priority")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("QcmQuestion");
                });

            modelBuilder.Entity("DAL.Entities.Candidat.Experience", b =>
                {
                    b.HasOne("DAL.Entities.User", null)
                        .WithMany("experiences")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DAL.Entities.Candidat.Technologie", b =>
                {
                    b.HasOne("DAL.Entities.Candidat.Candidat", null)
                        .WithMany("technologies")
                        .HasForeignKey("CandidatId");

                    b.HasOne("DAL.Entities.Candidat.Experience", null)
                        .WithMany("technologies")
                        .HasForeignKey("ExperienceId");
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
                        .HasForeignKey("employerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employer");
                });

            modelBuilder.Entity("DAL.Entities.Candidat.Experience", b =>
                {
                    b.Navigation("technologies");
                });

            modelBuilder.Entity("DAL.Entities.Test.Test", b =>
                {
                    b.Navigation("questions");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Navigation("experiences");
                });

            modelBuilder.Entity("DAL.Entities.Candidat.Candidat", b =>
                {
                    b.Navigation("technologies");
                });
#pragma warning restore 612, 618
        }
    }
}
