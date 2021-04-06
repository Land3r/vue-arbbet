﻿using System;
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
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sports_Sports_UnifiedEntityId",
                        column: x => x.UnifiedEntityId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
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
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competitions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competitions_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competitions_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
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
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Teams_UnifiedEntityId",
                        column: x => x.UnifiedEntityId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
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
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Events_UnifiedEntityId",
                        column: x => x.UnifiedEntityId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
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
                        principalTable: "Bets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bets_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventTeam",
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
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTeam_Teams_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outcomes",
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
                        principalTable: "Bets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Outcomes_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("01cb8b1d-5b7f-4545-aba0-a0b8bd46b9bf"), "FDJ", "FDJ" },
                    { new Guid("238d312e-d0b0-4108-9993-2cd322359f76"), "UNI", "Unibet" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Code", "Name", "PlatformId", "Platform_Id", "UnifiedEntityId", "UnifiedType" },
                values: new object[] { new Guid("685792bf-ed12-4b16-b54b-d7a6c08c0d74"), "FOO", "Football", null, null, null, "Master" });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Code", "Name", "PlatformId", "Platform_Id", "UnifiedEntityId", "UnifiedType" },
                values: new object[,]
                {
                    { new Guid("0405459e-dff5-4e98-9f18-cde23fe456ae"), "FOO", "Football", new Guid("01cb8b1d-5b7f-4545-aba0-a0b8bd46b9bf"), "100", new Guid("685792bf-ed12-4b16-b54b-d7a6c08c0d74"), "Platform" },
                    { new Guid("f9a054a5-99f5-47b0-967e-9e8ac005a147"), "FOO", "Football", new Guid("238d312e-d0b0-4108-9993-2cd322359f76"), null, new Guid("685792bf-ed12-4b16-b54b-d7a6c08c0d74"), "Platform" }
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
                name: "IX_Bets_UnifiedEntityId",
                table: "Bets",
                column: "UnifiedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CountryId",
                table: "Competitions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_PlatformId",
                table: "Competitions",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_SportId",
                table: "Competitions",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_UnifiedEntityId",
                table: "Competitions",
                column: "UnifiedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CompetitionId",
                table: "Events",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PlatformId",
                table: "Events",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UnifiedEntityId",
                table: "Events",
                column: "UnifiedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTeam_ParticipantsId",
                table: "EventTeam",
                column: "ParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_BetId",
                table: "Outcomes",
                column: "BetId");

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_TeamId",
                table: "Outcomes",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_Code",
                table: "Platforms",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_PlatformId",
                table: "Sports",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_UnifiedEntityId",
                table: "Sports",
                column: "UnifiedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryId",
                table: "Teams",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PlatformId",
                table: "Teams",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SportId",
                table: "Teams",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_UnifiedEntityId",
                table: "Teams",
                column: "UnifiedEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTeam");

            migrationBuilder.DropTable(
                name: "Outcomes");

            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}