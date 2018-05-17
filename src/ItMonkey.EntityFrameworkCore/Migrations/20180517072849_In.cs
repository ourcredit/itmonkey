using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ItMonkey.Migrations
{
    public partial class In : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SettlementType",
                table: "m_product");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "m_product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MonkeyCionDeal",
                table: "m_product",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "m_product");

            migrationBuilder.DropColumn(
                name: "MonkeyCionDeal",
                table: "m_product");

            migrationBuilder.AddColumn<int>(
                name: "SettlementType",
                table: "m_product",
                nullable: false,
                defaultValue: 0);
        }
    }
}
