using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeMachine.Data.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Badge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerLastName = table.Column<string>(nullable: false),
                    OwnerFirstName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drink",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BadgeId = table.Column<int>(nullable: false),
                    DrinkId = table.Column<int>(nullable: false),
                    WithMug = table.Column<bool>(nullable: false),
                    SugarAmount = table.Column<int>(nullable: false),
                    OrderTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Badge_BadgeId",
                        column: x => x.BadgeId,
                        principalTable: "Badge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Badge",
                columns: new[] { "Id", "OwnerFirstName", "OwnerLastName" },
                values: new object[,]
                {
                    { 1, "John", "Doe" },
                    { 2, "Jane", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Drink",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Coffee" },
                    { 2, "Tea" },
                    { 3, "Chocolate" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "BadgeId", "DrinkId", "OrderTime", "SugarAmount", "WithMug" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2020, 5, 10, 13, 45, 0, 0, DateTimeKind.Unspecified), 3, true },
                    { 2, 1, 2, new DateTime(2020, 5, 10, 17, 22, 13, 0, DateTimeKind.Unspecified), 2, true },
                    { 3, 2, 2, new DateTime(2020, 5, 10, 14, 11, 29, 0, DateTimeKind.Unspecified), 0, false },
                    { 4, 2, 3, new DateTime(2020, 5, 10, 15, 27, 52, 0, DateTimeKind.Unspecified), 1, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_BadgeId",
                table: "Order",
                column: "BadgeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drink");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Badge");
        }
    }
}
