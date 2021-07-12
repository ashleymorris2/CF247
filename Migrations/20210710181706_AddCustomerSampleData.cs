using Microsoft.EntityFrameworkCore.Migrations;

namespace CF247TechTest.API.Migrations
{
    public partial class AddCustomerSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "Password", "Surname" },
                values: new object[,]
                {
                    { 1, "aiyana.hue6@gmail.com", "Shirley", "ga5eiY8Ewee", "Murray" },
                    { 2, "marquis_les@gmail.com", "Matthew", "quieCoodi6P", "McNeill" },
                    { 3, "alvis2012@yahoo.com", "Richard ", "kahghei1aSu", "Headley" },
                    { 4, "palma_oconn@hotmail.com", "Elizabeth", "ceZui6ok", "Marcus" },
                    { 5, "eliseo2011@protonmail.com", "David", "shoop3Hoh", "Thomas" },
                    { 6, "berry1979@gmail.com", "Jerry", "Imah5oav", "Conway" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
