using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerieA.API.Migrations
{
    /// <inheritdoc />
    public partial class mig_addplayer_statistics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchStatistics_Teams_TeamId",
                table: "MatchStatistics");

            migrationBuilder.DropColumn(
                name: "PlayerIn",
                table: "Substitutions");

            migrationBuilder.DropColumn(
                name: "PlayerOut",
                table: "Substitutions");

            migrationBuilder.DropColumn(
                name: "AssistPlayerName",
                table: "MatchGoals");

            migrationBuilder.DropColumn(
                name: "PlayerName",
                table: "MatchGoals");

            migrationBuilder.DropColumn(
                name: "PlayerName",
                table: "MatchCards");

            migrationBuilder.AddColumn<int>(
                name: "PlayerInId",
                table: "Substitutions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerOutId",
                table: "Substitutions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AssistPlayerId",
                table: "MatchGoals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "MatchGoals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "MatchCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShirtNumber = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Substitutions_PlayerInId",
                table: "Substitutions",
                column: "PlayerInId");

            migrationBuilder.CreateIndex(
                name: "IX_Substitutions_PlayerOutId",
                table: "Substitutions",
                column: "PlayerOutId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGoals_AssistPlayerId",
                table: "MatchGoals",
                column: "AssistPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGoals_PlayerId",
                table: "MatchGoals",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchCards_PlayerId",
                table: "MatchCards",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchCards_Players_PlayerId",
                table: "MatchCards",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchGoals_Players_AssistPlayerId",
                table: "MatchGoals",
                column: "AssistPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchGoals_Players_PlayerId",
                table: "MatchGoals",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchStatistics_Teams_TeamId",
                table: "MatchStatistics",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Substitutions_Players_PlayerInId",
                table: "Substitutions",
                column: "PlayerInId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Substitutions_Players_PlayerOutId",
                table: "Substitutions",
                column: "PlayerOutId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchCards_Players_PlayerId",
                table: "MatchCards");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchGoals_Players_AssistPlayerId",
                table: "MatchGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchGoals_Players_PlayerId",
                table: "MatchGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchStatistics_Teams_TeamId",
                table: "MatchStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_Substitutions_Players_PlayerInId",
                table: "Substitutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Substitutions_Players_PlayerOutId",
                table: "Substitutions");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Substitutions_PlayerInId",
                table: "Substitutions");

            migrationBuilder.DropIndex(
                name: "IX_Substitutions_PlayerOutId",
                table: "Substitutions");

            migrationBuilder.DropIndex(
                name: "IX_MatchGoals_AssistPlayerId",
                table: "MatchGoals");

            migrationBuilder.DropIndex(
                name: "IX_MatchGoals_PlayerId",
                table: "MatchGoals");

            migrationBuilder.DropIndex(
                name: "IX_MatchCards_PlayerId",
                table: "MatchCards");

            migrationBuilder.DropColumn(
                name: "PlayerInId",
                table: "Substitutions");

            migrationBuilder.DropColumn(
                name: "PlayerOutId",
                table: "Substitutions");

            migrationBuilder.DropColumn(
                name: "AssistPlayerId",
                table: "MatchGoals");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "MatchGoals");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "MatchCards");

            migrationBuilder.AddColumn<string>(
                name: "PlayerIn",
                table: "Substitutions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayerOut",
                table: "Substitutions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssistPlayerName",
                table: "MatchGoals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlayerName",
                table: "MatchGoals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayerName",
                table: "MatchCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchStatistics_Teams_TeamId",
                table: "MatchStatistics",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
