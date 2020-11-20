using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DonarsService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(nullable: true),
                    TotalDonations = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donar",
                columns: table => new
                {
                    DonorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorName = table.Column<string>(nullable: true),
                    DateOfDonation = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donar", x => x.DonorId);
                    table.ForeignKey(
                        name: "FK_Donar_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donar_OrganizationId",
                table: "Donar",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donar");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
