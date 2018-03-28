using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ItMonkey.Migrations
{
    public partial class message : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PayState",
                table: "m_job",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AlterColumn<bool>(
                name: "VilidateState",
                table: "m_customer_job",
                nullable: true,
                oldClrType: typeof(bool));
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayState",
                table: "m_job");

            migrationBuilder.AlterColumn<bool>(
                name: "VilidateState",
                table: "m_customer_job",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
