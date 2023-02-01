using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventRegistration.Server.Data.Migrations
{
    public partial class AddApplicationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Categoryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoryname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categorydescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Categoryid);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customeraddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customeremail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customernumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customerid);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Staffid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Staffemail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Staffcontactnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Staffgender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Staffid);
                });

            migrationBuilder.CreateTable(
                name: "Venus",
                columns: table => new
                {
                    Venueid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Venuename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venueaddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venuedescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venus", x => x.Venueid);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customerid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Registrations_Customers_Customerid",
                        column: x => x.Customerid,
                        principalTable: "Customers",
                        principalColumn: "Customerid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Eventid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventVenue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventdateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventdateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventCreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventUpdatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venueid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Eventid);
                    table.ForeignKey(
                        name: "FK_Events_Venus_Venueid",
                        column: x => x.Venueid,
                        principalTable: "Venus",
                        principalColumn: "Venueid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Paymentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentdateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentdateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentCreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentUpdatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paymenttype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Totalpayment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Registrationid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Paymentid);
                    table.ForeignKey(
                        name: "FK_Payments_Registrations_Registrationid",
                        column: x => x.Registrationid,
                        principalTable: "Registrations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_Venueid",
                table: "Events",
                column: "Venueid");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Registrationid",
                table: "Payments",
                column: "Registrationid");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_Customerid",
                table: "Registrations",
                column: "Customerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Venus");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
