using Microsoft.EntityFrameworkCore.Migrations;

namespace EventRegistration.Server.Data.Migrations
{
    public partial class AddApplicationTables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Venus_Venueid",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venus",
                table: "Venus");

            migrationBuilder.RenameTable(
                name: "Venus",
                newName: "Venues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venues",
                table: "Venues",
                column: "Venueid");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Venues_Venueid",
                table: "Events",
                column: "Venueid",
                principalTable: "Venues",
                principalColumn: "Venueid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Venues_Venueid",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venues",
                table: "Venues");

            migrationBuilder.RenameTable(
                name: "Venues",
                newName: "Venus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venus",
                table: "Venus",
                column: "Venueid");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Venus_Venueid",
                table: "Events",
                column: "Venueid",
                principalTable: "Venus",
                principalColumn: "Venueid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
