using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WormGearKursovaya.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InputParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Z2 = table.Column<int>(type: "integer", nullable: false),
                    Z1 = table.Column<int>(type: "integer", nullable: false),
                    Q = table.Column<double>(type: "double precision", nullable: false),
                    SigmaHP = table.Column<double>(type: "double precision", nullable: false),
                    Efficiency = table.Column<double>(type: "double precision", nullable: false),
                    PowerN1 = table.Column<double>(type: "double precision", nullable: false),
                    SigmaFP = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calculations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CalculationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Aw = table.Column<double>(type: "double precision", nullable: false),
                    D2 = table.Column<double>(type: "double precision", nullable: false),
                    X = table.Column<double>(type: "double precision", nullable: false),
                    M = table.Column<double>(type: "double precision", nullable: false),
                    InputParameterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calculations_InputParameters_InputParameterId",
                        column: x => x.InputParameterId,
                        principalTable: "InputParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calculations_InputParameterId",
                table: "Calculations",
                column: "InputParameterId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculations");

            migrationBuilder.DropTable(
                name: "InputParameters");
        }
    }
}
