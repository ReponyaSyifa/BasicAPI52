﻿// <auto-generated />
using System;
using API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(MyContexts))]
    [Migration("20210618085719_changeIEnumtoICollect")]
    partial class changeIEnumtoICollect
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.Accounts", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIK");

                    b.ToTable("tb_m_accounts");
                });

            modelBuilder.Entity("API.Models.Educations", b =>
                {
                    b.Property<string>("EducationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniversitiesUniId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EducationId");

                    b.HasIndex("UniversitiesUniId");

                    b.ToTable("tb_m_educations");
                });

            modelBuilder.Entity("API.Models.Employees", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.ToTable("tb_m_employees");
                });

            modelBuilder.Entity("API.Models.Profilings", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EducationsEducationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NIK");

                    b.HasIndex("EducationsEducationId");

                    b.ToTable("tb_m_profilings");
                });

            modelBuilder.Entity("API.Models.Universities", b =>
                {
                    b.Property<string>("UniId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UniName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UniId");

                    b.ToTable("tb_m_universities");
                });

            modelBuilder.Entity("API.Models.Accounts", b =>
                {
                    b.HasOne("API.Models.Employees", "Employees")
                        .WithOne("Accounts")
                        .HasForeignKey("API.Models.Accounts", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("API.Models.Educations", b =>
                {
                    b.HasOne("API.Models.Universities", "Universities")
                        .WithMany("Educations")
                        .HasForeignKey("UniversitiesUniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Universities");
                });

            modelBuilder.Entity("API.Models.Profilings", b =>
                {
                    b.HasOne("API.Models.Educations", "Educations")
                        .WithMany("Profilings")
                        .HasForeignKey("EducationsEducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Accounts", "Accounts")
                        .WithOne("Profilings")
                        .HasForeignKey("API.Models.Profilings", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accounts");

                    b.Navigation("Educations");
                });

            modelBuilder.Entity("API.Models.Accounts", b =>
                {
                    b.Navigation("Profilings");
                });

            modelBuilder.Entity("API.Models.Educations", b =>
                {
                    b.Navigation("Profilings");
                });

            modelBuilder.Entity("API.Models.Employees", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("API.Models.Universities", b =>
                {
                    b.Navigation("Educations");
                });
#pragma warning restore 612, 618
        }
    }
}
