﻿// <auto-generated />
using MedServer.Domain.ValueObjects;
using MedServer.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace MedServer.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180212171210_ref12")]
    partial class ref12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MedServer.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodeRegister")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("MedServer.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Details")
                        .HasMaxLength(255);

                    b.Property<string>("Email")
                        .HasMaxLength(60);

                    b.Property<bool>("Enabled");

                    b.Property<int>("Gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("MedServer.Domain.Entities.PatientRecords", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfConsultation");

                    b.Property<int?>("DoctorId");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Memo");

                    b.Property<int?>("PatientId");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientRecords");
                });

            modelBuilder.Entity("MedServer.Domain.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateReg");

                    b.Property<int?>("DoctorId");

                    b.Property<DateTime>("Finish");

                    b.Property<DateTime>("Initial");

                    b.Property<int?>("PatientId");

                    b.Property<int>("Status");

                    b.Property<int?>("TypeConsultId");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("TypeConsultId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("MedServer.Domain.Entities.Secretary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Secretaries");
                });

            modelBuilder.Entity("MedServer.Domain.Entities.TypeConsult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("TypesConsult");
                });

            modelBuilder.Entity("MedServer.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<bool>("Enabled");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<int>("Permission");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MedServer.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("MedServer.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MedServer.Domain.Entities.PatientRecords", b =>
                {
                    b.HasOne("MedServer.Domain.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("MedServer.Domain.Entities.Patient", "Patient")
                        .WithMany("Records")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("MedServer.Domain.Entities.Schedule", b =>
                {
                    b.HasOne("MedServer.Domain.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("MedServer.Domain.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.HasOne("MedServer.Domain.Entities.TypeConsult", "TypeConsult")
                        .WithMany()
                        .HasForeignKey("TypeConsultId");
                });

            modelBuilder.Entity("MedServer.Domain.Entities.Secretary", b =>
                {
                    b.HasOne("MedServer.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
