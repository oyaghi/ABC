using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mid_Project.Migrations
{
    public partial class v_1 : Migration
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
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "trip_buss",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripID = table.Column<int>(type: "int", nullable: false),
                    BussID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trip_buss", x => x.ID);
                    table.ForeignKey(
                        name: "FK_trip_buss_buss_BussID",
                        column: x => x.BussID,
                        principalTable: "buss",
                        principalColumn: "bus_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trip_buss_trip_TripID",
                        column: x => x.TripID,
                        principalTable: "trip",
                        principalColumn: "trip_Id");
                });

            migrationBuilder.CreateTable(
                name: "trip_passenger",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripID = table.Column<int>(type: "int", nullable: false),
                    PassengerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trip_passenger", x => x.ID);
                    table.ForeignKey(
                        name: "FK_trip_passenger_passenger_PassengerID",
                        column: x => x.PassengerID,
                        principalTable: "passenger",
                        principalColumn: "pass_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trip_passenger_trip_TripID",
                        column: x => x.TripID,
                        principalTable: "trip",
                        principalColumn: "trip_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_admin_username",
                table: "admin",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_buss_AdminID",
                table: "buss",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_passenger_email",
                table: "passenger",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_passenger_username",
                table: "passenger",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trip_AdminID",
                table: "trip",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_trip_buss_BussID",
                table: "trip_buss",
                column: "BussID");

            migrationBuilder.CreateIndex(
                name: "IX_trip_buss_TripID",
                table: "trip_buss",
                column: "TripID");

            migrationBuilder.CreateIndex(
                name: "IX_trip_passenger_PassengerID",
                table: "trip_passenger",
                column: "PassengerID");

            migrationBuilder.CreateIndex(
                name: "IX_trip_passenger_TripID",
                table: "trip_passenger",
                column: "TripID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trip_buss");

            migrationBuilder.DropTable(
                name: "trip_passenger");

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
