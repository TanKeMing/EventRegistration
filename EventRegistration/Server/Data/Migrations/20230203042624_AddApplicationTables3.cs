using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventRegistration.Server.Data.Migrations
{
    public partial class AddApplicationTables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Venueid",
                table: "Venues",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Staffid",
                table: "Staffs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Registrations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PaymentdateUpdated",
                table: "Payments",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "PaymentdateCreated",
                table: "Payments",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "PaymentUpdatedby",
                table: "Payments",
                newName: "Updatedby");

            migrationBuilder.RenameColumn(
                name: "PaymentCreatedBy",
                table: "Payments",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Paymentid",
                table: "Payments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EventdateUpdated",
                table: "Events",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "EventdateCreated",
                table: "Events",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "EventUpdatedby",
                table: "Events",
                newName: "Updatedby");

            migrationBuilder.RenameColumn(
                name: "EventCreatedBy",
                table: "Events",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Eventid",
                table: "Events",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Customerid",
                table: "Customers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Categoryid",
                table: "Categorys",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Venues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Venues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Venues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Updatedby",
                table: "Venues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Staffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Staffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Updatedby",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Updatedby",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Categorys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Categorys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Categorys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Updatedby",
                table: "Categorys",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "Updatedby",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Updatedby",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Updatedby",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categorys");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Categorys");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Categorys");

            migrationBuilder.DropColumn(
                name: "Updatedby",
                table: "Categorys");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Venues",
                newName: "Venueid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Staffs",
                newName: "Staffid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Registrations",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Updatedby",
                table: "Payments",
                newName: "PaymentUpdatedby");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "Payments",
                newName: "PaymentdateUpdated");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Payments",
                newName: "PaymentdateCreated");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Payments",
                newName: "PaymentCreatedBy");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payments",
                newName: "Paymentid");

            migrationBuilder.RenameColumn(
                name: "Updatedby",
                table: "Events",
                newName: "EventUpdatedby");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "Events",
                newName: "EventdateUpdated");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Events",
                newName: "EventdateCreated");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Events",
                newName: "EventCreatedBy");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Events",
                newName: "Eventid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "Customerid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categorys",
                newName: "Categoryid");
        }
    }
}
