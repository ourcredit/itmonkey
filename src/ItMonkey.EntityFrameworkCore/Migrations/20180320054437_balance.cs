using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ItMonkey.Migrations
{
    public partial class balance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Balance",
                table: "m_customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ChildSkill",
                table: "m_customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "m_customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "m_customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "m_customer");

            migrationBuilder.DropColumn(
                name: "ChildSkill",
                table: "m_customer");

            migrationBuilder.DropColumn(
                name: "Skill",
                table: "m_customer");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "m_customer");
        }
    }
}
