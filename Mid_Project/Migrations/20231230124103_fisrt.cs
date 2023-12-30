using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mid_Project.Migrations
{
    public partial class fisrt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    admin_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.admin_Id);
                });

            migrationBuilder.CreateTable(
                name: "passenger",
                columns: table => new
                {
                    pass_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passenger", x => x.pass_Id);
                });

            migrationBuilder.CreateTable(
                name: "buss",
                columns: table => new
                {
                    bus_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    captin_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    number_of_seats = table.Column<int>(type: "int", nullable: false),
                    AdminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buss", x => x.bus_Id);
                    table.ForeignKey(
                        name: "FK_buss_admin_AdminID",
                        column: x => x.AdminID,
                        principalTable: "admin",
                        principalColumn: "admin_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trip",
                columns: table => new
                {
                    trip_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bus_Number = table.Column<int>(type: "int", nullable: false),
                    AdminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trip", x => x.trip_Id);
                    table.ForeignKey(
                        name: "FK_trip_admin_AdminID",
                        column: x => x.AdminID,
                        principalTable: "admin",
                        principalColumn: "admin_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BussTrip",
                columns: table => new
                {
                    bussbus_Id = table.Column<int>(type: "int", nullable: false),
                    trip_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BussTrip", x => new { x.bussbus_Id, x.trip_Id });
                    table.ForeignKey(
                        name: "FK_BussTrip_buss_bussbus_Id",
                        column: x => x.bussbus_Id,
                        principalTable: "buss",
                        principalColumn: "bus_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BussTrip_trip_trip_Id",
                        column: x => x.trip_Id,
                        principalTable: "trip",
                        principalColumn: "trip_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassengerTrip",
                columns: table => new
                {
                    passengerpass_Id = table.Column<int>(type: "int", nullable: false),
                    trip_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerTrip", x => new { x.passengerpass_Id, x.trip_Id });
                    table.ForeignKey(
                        name: "FK_PassengerTrip_passenger_passengerpass_Id",
                        column: x => x.passengerpass_Id,
                        principalTable: "passenger",
                        principalColumn: "pass_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassengerTrip_trip_trip_Id",
                        column: x => x.trip_Id,
                        principalTable: "trip",
                        principalColumn: "trip_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_buss_AdminID",
                table: "buss",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_BussTrip_trip_Id",
                table: "BussTrip",
                column: "trip_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerTrip_trip_Id",
                table: "PassengerTrip",
                column: "trip_Id");

            migrationBuilder.CreateIndex(
                name: "IX_trip_AdminID",
                table: "trip",
                column: "AdminID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BussTrip");

            migrationBuilder.DropTable(
                name: "PassengerTrip");

            migrationBuilder.DropTable(
                name: "buss");

            migrationBuilder.DropTable(
                name: "passenger");

            migrationBuilder.DropTable(
                name: "trip");

            migrationBuilder.DropTable(
                name: "admin");
        }
    }
}
