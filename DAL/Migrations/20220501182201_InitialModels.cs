using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assassin",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaxReward", "MinReward" },
                values: new object[] { 20m, 14m });

            migrationBuilder.UpdateData(
                table: "Assassin",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaxReward",
                value: 17m);

            migrationBuilder.UpdateData(
                table: "Assassin",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MaxReward", "MinReward" },
                values: new object[] { 26m, 11m });

            migrationBuilder.UpdateData(
                table: "Assassin",
                keyColumn: "Id",
                keyValue: 4,
                column: "MinReward",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Assassin",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MaxReward", "MinReward" },
                values: new object[] { 27m, 13m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assassin");

            migrationBuilder.DropTable(
                name: "Beggar");

            migrationBuilder.DropTable(
                name: "Fool");
        }
    }
}
