using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerieA.API.Migrations
{
    /// <inheritdoc />
    public partial class mig_assist_player_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssistPlayerName",
                table: "MatchGoals",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssistPlayerName",
                table: "MatchGoals");
        }
    }
}
