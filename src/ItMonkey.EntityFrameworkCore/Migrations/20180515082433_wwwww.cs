using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ItMonkey.Migrations
{
    public partial class wwwww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthenticationSource",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AbpUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsLockoutEnabled",
                table: "AbpUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTwoFactorEnabled",
                table: "AbpUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLockoutEnabled",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "IsTwoFactorEnabled",
                table: "AbpUsers");

            migrationBuilder.AddColumn<string>(
                name: "AuthenticationSource",
                table: "AbpUsers",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AbpUsers",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }
    }
}
