using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ItMonkey.Migrations
{
    public partial class wwww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "m_job");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "m_customer_job");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "m_customer_job",
                newName: "VilidateState");

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "m_customer_job",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<long>(
                name: "CreatorId",
                table: "m_customer_job",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "m_customer_job");

            migrationBuilder.RenameColumn(
                name: "VilidateState",
                table: "m_customer_job",
                newName: "IsDeleted");

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "m_job",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "m_customer_job",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "m_customer_job",
                nullable: true);
        }
    }
}
