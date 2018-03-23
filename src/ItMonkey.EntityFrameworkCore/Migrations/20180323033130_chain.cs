using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ItMonkey.Migrations
{
    public partial class chain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_monkey_chain",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    Hash = table.Column<string>(nullable: true),
                    Index = table.Column<long>(nullable: false),
                    PreviousHash = table.Column<string>(nullable: true),
                    TimeSpan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_monkey_chain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "m_user_monkey_chain",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    CustomerId = table.Column<long>(nullable: false),
                    Hash = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_user_monkey_chain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_m_user_monkey_chain_m_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "m_customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_user_monkey_chain_CustomerId",
                table: "m_user_monkey_chain",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_monkey_chain");

            migrationBuilder.DropTable(
                name: "m_user_monkey_chain");
        }
    }
}
