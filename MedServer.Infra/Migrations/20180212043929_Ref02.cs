using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MedServer.Infra.Migrations
{
    public partial class Ref02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Doctors_DoctorId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Patients_PatientId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_TypesConsult_TypeConsultId",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedules");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_TypeConsultId",
                table: "Schedules",
                newName: "IX_Schedules_TypeConsultId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_PatientId",
                table: "Schedules",
                newName: "IX_Schedules_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_DoctorId",
                table: "Schedules",
                newName: "IX_Schedules_DoctorId");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Patients",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Patients",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Patients",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Doctors_DoctorId",
                table: "Schedules",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Patients_PatientId",
                table: "Schedules",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_TypesConsult_TypeConsultId",
                table: "Schedules",
                column: "TypeConsultId",
                principalTable: "TypesConsult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Doctors_DoctorId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Patients_PatientId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_TypesConsult_TypeConsultId",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_TypeConsultId",
                table: "Schedule",
                newName: "IX_Schedule_TypeConsultId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_PatientId",
                table: "Schedule",
                newName: "IX_Schedule_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_DoctorId",
                table: "Schedule",
                newName: "IX_Schedule_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Doctors_DoctorId",
                table: "Schedule",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Patients_PatientId",
                table: "Schedule",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_TypesConsult_TypeConsultId",
                table: "Schedule",
                column: "TypeConsultId",
                principalTable: "TypesConsult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
