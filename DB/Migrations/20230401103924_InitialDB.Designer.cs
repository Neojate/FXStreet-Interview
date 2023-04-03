﻿// <auto-generated />
using System;
using Football.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fotball.DB.Migrations
{
    [DbContext(typeof(FootballContext))]
    [Migration("20230401103924_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Football.DB.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RedCard")
                        .HasColumnType("int");

                    b.Property<int>("YellowCard")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Football.DB.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AwayManagerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HouseManagerId")
                        .HasColumnType("int");

                    b.Property<int?>("RefereeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AwayManagerId");

                    b.HasIndex("HouseManagerId");

                    b.HasIndex("RefereeId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Football.DB.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MinutesPlayed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RedCard")
                        .HasColumnType("int");

                    b.Property<int>("YellowCard")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Football.DB.Models.Referee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MinutesPlayed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Referees");
                });

            modelBuilder.Entity("Fotball.DB.Models.AwayPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("AwayPlayer");
                });

            modelBuilder.Entity("Fotball.DB.Models.HousePlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("HousePlayer");
                });

            modelBuilder.Entity("Football.DB.Models.Match", b =>
                {
                    b.HasOne("Football.DB.Models.Manager", "AwayManager")
                        .WithMany()
                        .HasForeignKey("AwayManagerId");

                    b.HasOne("Football.DB.Models.Manager", "HouseManager")
                        .WithMany()
                        .HasForeignKey("HouseManagerId");

                    b.HasOne("Football.DB.Models.Referee", "Referee")
                        .WithMany("Matches")
                        .HasForeignKey("RefereeId");
                });

            modelBuilder.Entity("Fotball.DB.Models.AwayPlayer", b =>
                {
                    b.HasOne("Football.DB.Models.Match", "Match")
                        .WithMany("AwayPlayers")
                        .HasForeignKey("MatchId");

                    b.HasOne("Football.DB.Models.Player", "Player")
                        .WithMany("AwayPlayers")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Fotball.DB.Models.HousePlayer", b =>
                {
                    b.HasOne("Football.DB.Models.Match", "Match")
                        .WithMany("HousePlayers")
                        .HasForeignKey("MatchId");

                    b.HasOne("Football.DB.Models.Player", "Player")
                        .WithMany("HousePlayers")
                        .HasForeignKey("PlayerId");
                });
#pragma warning restore 612, 618
        }
    }
}