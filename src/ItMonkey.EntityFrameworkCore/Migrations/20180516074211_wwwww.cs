using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ItMonkey.Migrations
{
    public partial class wwwww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "m_customer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "m_customer_address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Consignee = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    Mobile = table.Column<string>(nullable: true),
                    OpenId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_customer_address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "m_order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Buyer = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    OpenId = table.Column<string>(nullable: true),
                    OrderType = table.Column<string>(nullable: true),
                    PayState = table.Column<bool>(nullable: true),
                    PostInfo = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    State = table.Column<bool>(nullable: true),
                    WeChatOrder = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "m_product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    ProductCount = table.Column<int>(nullable: false),
                    ProductDescription = table.Column<string>(nullable: true),
                    ProductImage = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(maxLength: 200, nullable: false),
                    SettlementType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_customer_address");

            migrationBuilder.DropTable(
                name: "m_order");

            migrationBuilder.DropTable(
                name: "m_product");

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "m_customer");
        }
    }
}
