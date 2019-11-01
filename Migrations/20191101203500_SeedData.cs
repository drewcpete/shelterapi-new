using Microsoft.EntityFrameworkCore.Migrations;

namespace animalshelterapi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "ID", "Age", "Gender", "Name", "Species" },
                values: new object[] { 1, 5, "Male", "Boston Rob", "Boston Terrier" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
