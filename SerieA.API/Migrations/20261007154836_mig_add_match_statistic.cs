using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerieA.API.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_match_statistic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Possession = table.Column<int>(type: "int", nullable: false),
                    Shots = table.Column<int>(type: "int", nullable: false),
                    ShotsOnTarget = table.Column<int>(type: "int", nullable: false),
                    Passes = table.Column<int>(type: "int", nullable: false),
                    PassAccuracy = table.Column<int>(type: "int", nullable: false),
                    Corners = table.Column<int>(type: "int", nullable: false),
                    Fouls = table.Column<int>(type: "int", nullable: false),
                    Offsides = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchStatistics_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchStatistics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatistics_MatchId",
                table: "MatchStatistics",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatistics_TeamId",
                table: "MatchStatistics",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchStatistics");
        }
    }
}
