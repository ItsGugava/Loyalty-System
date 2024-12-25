using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyalty_System.Migrations
{
    /// <inheritdoc />
    public partial class PointsLogsDbsInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccumulatePointsLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccumulatePointsLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccumulatePointsLogs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpendPointsLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpendPointsLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpendPointsLogs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccumulatePointsLogs_CheckId",
                table: "AccumulatePointsLogs",
                column: "CheckId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccumulatePointsLogs_CustomerId",
                table: "AccumulatePointsLogs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpendPointsLogs_CheckId",
                table: "SpendPointsLogs",
                column: "CheckId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpendPointsLogs_CustomerId",
                table: "SpendPointsLogs",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccumulatePointsLogs");

            migrationBuilder.DropTable(
                name: "SpendPointsLogs");
        }
    }
}
