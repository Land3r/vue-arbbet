﻿// <auto-generated />
using System;
using Arbbet.Connectors.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Arbbet.Connectors.Dal.Migrations
{
    [DbContext(typeof(ConnectorDbContext))]
    [Migration("20210228002740_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Arbbet.Connectors.Domain.Bets.Bet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BetType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IdPlatform")
                        .HasColumnType("text");

                    b.Property<decimal>("Odd_Draw_A")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Odd_Lose_A")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Odd_Win_A")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("PlatformId")
                        .HasColumnType("uuid");

                    b.Property<string>("Team_AId")
                        .HasColumnType("text");

                    b.Property<string>("Team_BId")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PlatformId");

                    b.HasIndex("Team_AId");

                    b.HasIndex("Team_BId");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("Arbbet.Connectors.Domain.Competitions.Competition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<string>("IdFdj")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("Arbbet.Connectors.Domain.Countries.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Arbbet.Connectors.Domain.Events.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CompetitionId")
                        .HasColumnType("uuid");

                    b.Property<string>("IdFdj")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Arbbet.Connectors.Domain.Platforms.Platform", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("Arbbet.Connectors.Domain.Sports.Sport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("IdFdj")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sports");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0405459e-dff5-4e98-9f18-cde23fe456ae"),
                            Code = "FOO",
                            IdFdj = "100",
                            Name = "Football"
                        },
                        new
                        {
                            Id = new Guid("a588cc21-4797-4916-95ec-fc54e7bacd44"),
                            Code = "TEN",
                            IdFdj = "600",
                            Name = "Tennis"
                        },
                        new
                        {
                            Id = new Guid("4c855310-ec82-48dd-9ba5-9bd611804d4e"),
                            Code = "BAS",
                            IdFdj = "601600",
                            Name = "Basketball"
                        },
                        new
                        {
                            Id = new Guid("6dc779c4-113f-4aa5-855a-65959b0426cf"),
                            Code = "RUG",
                            IdFdj = "964500",
                            Name = "Rugby"
                        },
                        new
                        {
                            Id = new Guid("b3082cf0-1ce3-4ee0-8a2a-105055f3d851"),
                            Code = "VOL",
                            IdFdj = "1200",
                            Name = "Volley"
                        },
                        new
                        {
                            Id = new Guid("43730787-c53e-49a1-80a2-4db01d95d38a"),
                            Code = "HAN",
                            IdFdj = "1100",
                            Name = "Handball"
                        },
                        new
                        {
                            Id = new Guid("ca33fb07-fd55-4c25-8ef9-7a62e75be407"),
                            Code = "HOC",
                            IdFdj = "2100",
                            Name = "Hockey"
                        },
                        new
                        {
                            Id = new Guid("3478ac3e-b02b-46ab-9db4-716519476f73"),
                            Code = "BOX",
                            IdFdj = "364800",
                            Name = "Boxe"
                        });
                });

            modelBuilder.Entity("Arbbet.Connectors.Domain.Teams.Team", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("TeamType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Arbbet.Connectors.Domain.Bets.Bet", b =>
                {
                    b.HasOne("Arbbet.Connectors.Domain.Events.Event", null)
                        .WithMany("Bets")
                        .HasForeignKey("EventId");

                    b.HasOne("Arbbet.Connectors.Domain.Platforms.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId");

                    b.HasOne("Arbbet.Connectors.Domain.Teams.Team", "Team_A")
                        .WithMany()
                        .HasForeignKey("Team_AId");

                    b.HasOne("Arbbet.Connectors.Domain.Teams.Team", "Team_B")
                        .WithMany()
                        .HasForeignKey("Team_BId");

                    b.Navigation("Platform");

                    b.Navigation("Team_A");

                    b.Navigation("Team_B");
                });

            modelBuilder.Entity("Arbbet.Connectors.Domain.Competitions.Competition", b =>
                {
                    b.HasOne("Arbbet.Connectors.Domain.Countries.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Arbbet.Connectors.Domain.Events.Event", b =>
                {
                    b.HasOne("Arbbet.Connectors.Domain.Competitions.Competition", "Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId");

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("Arbbet.Connectors.Domain.Teams.Team", b =>
                {
                    b.HasOne("Arbbet.Connectors.Domain.Countries.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Arbbet.Connectors.Domain.Events.Event", b =>
                {
                    b.Navigation("Bets");
                });
#pragma warning restore 612, 618
        }
    }
}
