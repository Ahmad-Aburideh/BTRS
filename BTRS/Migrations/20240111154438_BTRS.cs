using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTRS.Migrations
{
    public partial class BTRS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "bookingtrips",
                columns: table => new
                {
                    TripID = table.Column<int>(type: "int", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingtrips", x => x.TripID);
                });

            migrationBuilder.CreateTable(
                name: "passengers",
                columns: table => new
                {
                    PassengerID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passengers", x => x.PassengerID);
                });

            migrationBuilder.CreateTable(
                name: "trip",
                columns: table => new
                {
                    TripID = table.Column<int>(type: "int", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerID = table.Column<int>(type: "int", nullable: true),
                    administratorAdminID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trip", x => x.TripID);
                    table.ForeignKey(
                        name: "FK_trip_admins_administratorAdminID",
                        column: x => x.administratorAdminID,
                        principalTable: "admins",
                        principalColumn: "AdminID");
                    table.ForeignKey(
                        name: "FK_trip_passengers_PassengerID",
                        column: x => x.PassengerID,
                        principalTable: "passengers",
                        principalColumn: "PassengerID");
                });

            migrationBuilder.CreateTable(
                name: "bus",
                columns: table => new
                {
                    BusID = table.Column<int>(type: "int", nullable: false),
                    CaptainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    TripID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bus", x => x.BusID);
                    table.ForeignKey(
                        name: "FK_bus_trip_TripID",
                        column: x => x.TripID,
                        principalTable: "trip",
                        principalColumn: "TripID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bus_TripID",
                table: "bus",
                column: "TripID");

            migrationBuilder.CreateIndex(
                name: "IX_trip_administratorAdminID",
                table: "trip",
                column: "administratorAdminID");

            migrationBuilder.CreateIndex(
                name: "IX_trip_PassengerID",
                table: "trip",
                column: "PassengerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingtrips");

            migrationBuilder.DropTable(
                name: "bus");

            migrationBuilder.DropTable(
                name: "trip");

            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "passengers");
        }
    }
}
