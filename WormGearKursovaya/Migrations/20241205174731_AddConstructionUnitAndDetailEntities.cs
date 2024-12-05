using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WormGearKursovaya.Migrations
{
    /// <inheritdoc />
    public partial class AddConstructionUnitAndDetailEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculations");

            migrationBuilder.DropTable(
                name: "InputParameters");

            migrationBuilder.CreateTable(
                name: "ConstructionUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<double>(type: "double precision", nullable: false),
                    N = table.Column<double>(type: "double precision", nullable: false),
                    Kfl = table.Column<double>(type: "double precision", nullable: false),
                    Aw = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Z1 = table.Column<double>(type: "double precision", nullable: false),
                    Z2 = table.Column<int>(type: "integer", nullable: false),
                    SigmaHP = table.Column<double>(type: "double precision", nullable: false),
                    X = table.Column<double>(type: "double precision", nullable: false),
                    N = table.Column<double>(type: "double precision", nullable: false),
                    Kfl = table.Column<double>(type: "double precision", nullable: false),
                    Aw = table.Column<double>(type: "double precision", nullable: false),
                    M = table.Column<double>(type: "double precision", nullable: false),
                    T2 = table.Column<double>(type: "double precision", nullable: false),
                    N1 = table.Column<double>(type: "double precision", nullable: false),
                    ConstructionUnitId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_ConstructionUnits_ConstructionUnitId",
                        column: x => x.ConstructionUnitId,
                        principalTable: "ConstructionUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_ConstructionUnitId",
                table: "Details",
                column: "ConstructionUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "ConstructionUnits");

            migrationBuilder.CreateTable(
                name: "InputParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Efficiency = table.Column<double>(type: "double precision", nullable: false),
                    PowerN1 = table.Column<double>(type: "double precision", nullable: false),
                    Q = table.Column<double>(type: "double precision", nullable: false),
                    SigmaFP = table.Column<double>(type: "double precision", nullable: false),
                    SigmaHP = table.Column<double>(type: "double precision", nullable: false),
                    Z1 = table.Column<int>(type: "integer", nullable: false),
                    Z2 = table.Column<int>(type: "integer", nullable: false)
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
                    InputParameterId = table.Column<int>(type: "integer", nullable: false),
                    Aw = table.Column<double>(type: "double precision", nullable: false),
                    CalculationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    D2 = table.Column<double>(type: "double precision", nullable: false),
                    M = table.Column<double>(type: "double precision", nullable: false),
                    X = table.Column<double>(type: "double precision", nullable: false)
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
    }
}
