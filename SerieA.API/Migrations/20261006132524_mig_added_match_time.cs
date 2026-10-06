using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerieA.API.Migrations
{
    /// <inheritdoc />
    public partial class mig_added_match_time : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MatchTime",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatchTime",
                table: "Matches");
        }
    }
}
