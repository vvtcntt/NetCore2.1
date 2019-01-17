using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Data.EF.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionMeta",
                table: "Configs",
                type: "varchar(500)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeywordMeta",
                table: "Configs",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleMeta",
                table: "Configs",
                type: "varchar(255)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionMeta",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "KeywordMeta",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "TitleMeta",
                table: "Configs");
        }
    }
}
