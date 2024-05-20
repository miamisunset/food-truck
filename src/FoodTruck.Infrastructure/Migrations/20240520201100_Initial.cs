using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruck.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MobileFoodFacilities",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Applicant = table.Column<string>(type: "TEXT", nullable: false),
                    FacilityType = table.Column<string>(type: "TEXT", nullable: true),
                    Cnn = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    BlockLot = table.Column<string>(type: "TEXT", nullable: true),
                    Block = table.Column<string>(type: "TEXT", nullable: true),
                    Lot = table.Column<string>(type: "TEXT", nullable: true),
                    Permit = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    FoodItems = table.Column<string>(type: "TEXT", nullable: true),
                    X = table.Column<int>(type: "INTEGER", nullable: true),
                    Y = table.Column<int>(type: "INTEGER", nullable: true),
                    Latitude = table.Column<int>(type: "INTEGER", nullable: false),
                    Longitude = table.Column<int>(type: "INTEGER", nullable: false),
                    Schedule = table.Column<string>(type: "TEXT", nullable: false),
                    DaysHours = table.Column<string>(type: "TEXT", nullable: true),
                    Approved = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Received = table.Column<int>(type: "INTEGER", nullable: false),
                    PriorPermit = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FirePreventionDistricts = table.Column<int>(type: "INTEGER", nullable: true),
                    PoliceDistricts = table.Column<int>(type: "INTEGER", nullable: true),
                    SupervisorDistricts = table.Column<int>(type: "INTEGER", nullable: true),
                    ZipCodes = table.Column<int>(type: "INTEGER", nullable: true),
                    Neighborhoods = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileFoodFacilities", x => x.LocationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobileFoodFacilities");
        }
    }
}
