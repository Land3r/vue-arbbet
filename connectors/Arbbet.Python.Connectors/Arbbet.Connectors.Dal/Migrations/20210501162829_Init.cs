using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbbet.Connectors.Dal.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Domain");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                schema: "Domain",
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
                schema: "Domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    PlatformId = table.Column<Guid>(type: "uuid", nullable: true),
                    Platform_Id = table.Column<string>(type: "text", nullable: true),
                    UnifiedEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    UnifiedType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sports_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalSchema: "Domain",
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sports_Sports_UnifiedEntityId",
                        column: x => x.UnifiedEntityId,
                        principalSchema: "Domain",
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                schema: "Domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SportId = table.Column<Guid>(type: "uuid", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: true),
                    PlatformId = table.Column<Guid>(type: "uuid", nullable: true),
                    Platform_Id = table.Column<string>(type: "text", nullable: true),
                    UnifiedEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    UnifiedType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitions_Competitions_UnifiedEntityId",
                        column: x => x.UnifiedEntityId,
                        principalSchema: "Domain",
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competitions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Domain",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competitions_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalSchema: "Domain",
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competitions_Sports_SportId",
                        column: x => x.SportId,
                        principalSchema: "Domain",
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                schema: "Domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    TeamType = table.Column<string>(type: "text", nullable: false),
                    SportId = table.Column<Guid>(type: "uuid", nullable: true),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: true),
                    PlatformId = table.Column<Guid>(type: "uuid", nullable: true),
                    Platform_Id = table.Column<string>(type: "text", nullable: true),
                    UnifiedEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    UnifiedType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Domain",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalSchema: "Domain",
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Sports_SportId",
                        column: x => x.SportId,
                        principalSchema: "Domain",
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Teams_UnifiedEntityId",
                        column: x => x.UnifiedEntityId,
                        principalSchema: "Domain",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "Domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    EventType = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CompetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    PlatformId = table.Column<Guid>(type: "uuid", nullable: true),
                    Platform_Id = table.Column<string>(type: "text", nullable: true),
                    UnifiedEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    UnifiedType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalSchema: "Domain",
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Events_UnifiedEntityId",
                        column: x => x.UnifiedEntityId,
                        principalSchema: "Domain",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalSchema: "Domain",
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                schema: "Domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    BetType = table.Column<string>(type: "text", nullable: false),
                    PlatformId = table.Column<Guid>(type: "uuid", nullable: true),
                    Platform_Id = table.Column<string>(type: "text", nullable: true),
                    UnifiedEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    UnifiedType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bets_Bets_UnifiedEntityId",
                        column: x => x.UnifiedEntityId,
                        principalSchema: "Domain",
                        principalTable: "Bets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bets_Events_EventId",
                        column: x => x.EventId,
                        principalSchema: "Domain",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bets_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalSchema: "Domain",
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventTeam",
                schema: "Domain",
                columns: table => new
                {
                    EventsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParticipantsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTeam", x => new { x.EventsId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_EventTeam_Events_EventsId",
                        column: x => x.EventsId,
                        principalSchema: "Domain",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTeam_Teams_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalSchema: "Domain",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outcomes",
                schema: "Domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Odd = table.Column<decimal>(type: "numeric", nullable: false),
                    OutcomeType = table.Column<string>(type: "text", nullable: false),
                    BetId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeamId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outcomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outcomes_Bets_BetId",
                        column: x => x.BetId,
                        principalSchema: "Domain",
                        principalTable: "Bets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Outcomes_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "Domain",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Domain",
                table: "Platforms",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("01cb8b1d-5b7f-4545-aba0-a0b8bd46b9bf"), "FDJ", "FDJ" },
                    { new Guid("238d312e-d0b0-4108-9993-2cd322359f76"), "UNI", "Unibet" }
                });

            migrationBuilder.InsertData(
                schema: "Domain",
                table: "Sports",
                columns: new[] { "Id", "Code", "Name", "PlatformId", "Platform_Id", "UnifiedEntityId", "UnifiedType" },
                values: new object[] { new Guid("685792bf-ed12-4b16-b54b-d7a6c08c0d74"), "FOO", "Football", null, null, null, "Master" });

            migrationBuilder.InsertData(
                schema: "Domain",
                table: "Sports",
                columns: new[] { "Id", "Code", "Name", "PlatformId", "Platform_Id", "UnifiedEntityId", "UnifiedType" },
                values: new object[,]
                {
                    { new Guid("0405459e-dff5-4e98-9f18-cde23fe456ae"), "FOO", "Football", new Guid("01cb8b1d-5b7f-4545-aba0-a0b8bd46b9bf"), "100", new Guid("685792bf-ed12-4b16-b54b-d7a6c08c0d74"), "Platform" },
                    { new Guid("f9a054a5-99f5-47b0-967e-9e8ac005a147"), "FOO", "Football", new Guid("238d312e-d0b0-4108-9993-2cd322359f76"), null, new Guid("685792bf-ed12-4b16-b54b-d7a6c08c0d74"), "Platform" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_EventId",
                schema: "Domain",
                table: "Bets",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_PlatformId",
                schema: "Domain",
                table: "Bets",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_UnifiedEntityId",
                schema: "Domain",
                table: "Bets",
                column: "UnifiedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CountryId",
                schema: "Domain",
                table: "Competitions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_PlatformId",
                schema: "Domain",
                table: "Competitions",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_SportId",
                schema: "Domain",
                table: "Competitions",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_UnifiedEntityId",
                schema: "Domain",
                table: "Competitions",
                column: "UnifiedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CompetitionId",
                schema: "Domain",
                table: "Events",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PlatformId",
                schema: "Domain",
                table: "Events",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UnifiedEntityId",
                schema: "Domain",
                table: "Events",
                column: "UnifiedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTeam_ParticipantsId",
                schema: "Domain",
                table: "EventTeam",
                column: "ParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_BetId",
                schema: "Domain",
                table: "Outcomes",
                column: "BetId");

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_TeamId",
                schema: "Domain",
                table: "Outcomes",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_Code",
                schema: "Domain",
                table: "Platforms",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_PlatformId",
                schema: "Domain",
                table: "Sports",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_UnifiedEntityId",
                schema: "Domain",
                table: "Sports",
                column: "UnifiedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryId",
                schema: "Domain",
                table: "Teams",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PlatformId",
                schema: "Domain",
                table: "Teams",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SportId",
                schema: "Domain",
                table: "Teams",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_UnifiedEntityId",
                schema: "Domain",
                table: "Teams",
                column: "UnifiedEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTeam",
                schema: "Domain");

            migrationBuilder.DropTable(
                name: "Outcomes",
                schema: "Domain");

            migrationBuilder.DropTable(
                name: "Bets",
                schema: "Domain");

            migrationBuilder.DropTable(
                name: "Teams",
                schema: "Domain");

            migrationBuilder.DropTable(
                name: "Events",
                schema: "Domain");

            migrationBuilder.DropTable(
                name: "Competitions",
                schema: "Domain");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Domain");

            migrationBuilder.DropTable(
                name: "Sports",
                schema: "Domain");

            migrationBuilder.DropTable(
                name: "Platforms",
                schema: "Domain");
        }
    }
}
