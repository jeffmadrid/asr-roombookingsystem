using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asr.Data.Migrations
{
    public partial class MoreModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StaffID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomID);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<string>(maxLength: 6, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<string>(maxLength: 8, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Slot",
                columns: table => new
                {
                    RoomID = table.Column<string>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    StaffID = table.Column<string>(nullable: false),
                    StudentID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => new { x.RoomID, x.StartTime });
                    table.ForeignKey(
                        name: "FK_Slot_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slot_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slot_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StaffID",
                table: "AspNetUsers",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentID",
                table: "AspNetUsers",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_StaffID",
                table: "Slot",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_StudentID",
                table: "Slot",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Staff_StaffID",
                table: "AspNetUsers",
                column: "StaffID",
                principalTable: "Staff",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Student_StudentID",
                table: "AspNetUsers",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Staff_StaffID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Student_StudentID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Slot");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StaffID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudentID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "AspNetUsers");
        }
    }
}
