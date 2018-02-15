using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MedServer.Infra.Migrations
{
    public partial class Ref13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 32);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60);
        }
    }
}
