using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventRegistration.Server.Data.Migrations
{
    public partial class AddApplicationTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Registrationtime",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Paymentdatein",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Paymentdateout",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Eventdatein",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Eventdateout",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Eventtime",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Registrationtime",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "Paymentdatein",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Paymentdateout",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Eventdatein",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Eventdateout",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Eventtime",
                table: "Events");
        }
    }
}
