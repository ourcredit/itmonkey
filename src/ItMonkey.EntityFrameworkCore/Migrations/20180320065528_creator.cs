using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ItMonkey.Migrations
{
    public partial class creator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatorId",
                table: "m_job",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "FirstGrade",
                table: "m_job",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSecert",
                table: "m_job",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SecondGrade",
                table: "m_job",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThirdGrade",
                table: "m_job",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_m_job_CreatorId",
                table: "m_job",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_m_job_m_customer_CreatorId",
                table: "m_job",
                column: "CreatorId",
                principalTable: "m_customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_m_job_m_customer_CreatorId",
                table: "m_job");

            migrationBuilder.DropIndex(
                name: "IX_m_job_CreatorId",
                table: "m_job");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "m_job");

            migrationBuilder.DropColumn(
                name: "FirstGrade",
                table: "m_job");

            migrationBuilder.DropColumn(
                name: "IsSecert",
                table: "m_job");

            migrationBuilder.DropColumn(
                name: "SecondGrade",
                table: "m_job");

            migrationBuilder.DropColumn(
                name: "ThirdGrade",
                table: "m_job");
        }
    }
}
