using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ItMonkey.Migrations
{
    public partial class wwww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverAvator",
                table: "s_message_store",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderAvator",
                table: "s_message_store",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverAvator",
                table: "s_message_store");

            migrationBuilder.DropColumn(
                name: "SenderAvator",
                table: "s_message_store");
        }
    }
}
