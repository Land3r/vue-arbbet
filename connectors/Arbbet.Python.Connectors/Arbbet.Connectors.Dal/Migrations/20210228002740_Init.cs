using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbbet.Connectors.Dal.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    IdFdj = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdFdj = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: true),
                    TeamType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CompetitionId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdFdj = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Team_AId = table.Column<string>(type: "text", nullable: true),
                    Team_BId = table.Column<string>(type: "text", nullable: true),
                    BetType = table.Column<string>(type: "text", nullable: false),
                    Odd_Win_A = table.Column<decimal>(type: "numeric", nullable: false),
                    Odd_Draw_A = table.Column<decimal>(type: "numeric", nullable: false),
                    Odd_Lose_A = table.Column<decimal>(type: "numeric", nullable: false),
                    PlatformId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdPlatform = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bets_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bets_Teams_Team_AId",
                        column: x => x.Team_AId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bets_Teams_Team_BId",
                        column: x => x.Team_BId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Code", "IdFdj", "Name" },
                values: new object[,]
                {
                    { new Guid("0405459e-dff5-4e98-9f18-cde23fe456ae"), "FOO", "100", "Football" },
                    { new Guid("a588cc21-4797-4916-95ec-fc54e7bacd44"), "TEN", "600", "Tennis" },
                    { new Guid("4c855310-ec82-48dd-9ba5-9bd611804d4e"), "BAS", "601600", "Basketball" },
                    { new Guid("6dc779c4-113f-4aa5-855a-65959b0426cf"), "RUG", "964500", "Rugby" },
                    { new Guid("b3082cf0-1ce3-4ee0-8a2a-105055f3d851"), "VOL", "1200", "Volley" },
                    { new Guid("43730787-c53e-49a1-80a2-4db01d95d38a"), "HAN", "1100", "Handball" },
                    { new Guid("ca33fb07-fd55-4c25-8ef9-7a62e75be407"), "HOC", "2100", "Hockey" },
                    { new Guid("3478ac3e-b02b-46ab-9db4-716519476f73"), "BOX", "364800", "Boxe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_EventId",
                table: "Bets",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_PlatformId",
                table: "Bets",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_Team_AId",
                table: "Bets",
                column: "Team_AId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_Team_BId",
                table: "Bets",
                column: "Team_BId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CountryId",
                table: "Competitions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CompetitionId",
                table: "Events",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryId",
                table: "Teams",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
