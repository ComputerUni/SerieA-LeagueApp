using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerieA.API.Migrations
{
    /// <inheritdoc />
    public partial class update_team : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoundationYear",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Teams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryColor",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Region",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryColor",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortCode",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StadiumCapacity",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoundationYear",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "PrimaryColor",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "SecondaryColor",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ShortCode",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "StadiumCapacity",
                table: "Teams");
        }
    }
}
