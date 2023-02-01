using Microsoft.EntityFrameworkCore.Migrations;

namespace EventRegistration.Server.Data.Migrations
{
    public partial class AddedDefaultDataAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Staffid", "Staffcontactnumber", "Staffemail", "Staffgender" },
                values: new object[,]
                {
                    { 1, "89422042", "kolan@gmail.com", "female" },
                    { 2, "99427042", "sam@gmail.com", "male" }
                });

            migrationBuilder.InsertData(
                table: "Venus",
                columns: new[] { "Venueid", "Venueaddress", "Venuedescription", "Venuename" },
                values: new object[,]
                {
                    { 1, " Changi", "Tech show", "Expo" },
                    { 2, "Tampines Heartbeat", "Food show", "Tampines Hall" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Staffid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Staffid",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Venus",
                keyColumn: "Venueid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Venus",
                keyColumn: "Venueid",
                keyValue: 2);
        }
    }
}
