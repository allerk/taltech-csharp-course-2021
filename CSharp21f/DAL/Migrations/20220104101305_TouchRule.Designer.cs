﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220104101305_TouchRule")]
    partial class TouchRule
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.GameBoard", b =>
                {
                    b.Property<int>("GameBoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameBoardId"), 1L, 1);

                    b.Property<string>("BoardData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameConfigId")
                        .HasColumnType("int");

                    b.HasKey("GameBoardId");

                    b.HasIndex("GameConfigId");

                    b.ToTable("GameBoards");
                });

            modelBuilder.Entity("Domain.GameConfig", b =>
                {
                    b.Property<int>("GameConfigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameConfigId"), 1L, 1);

                    b.Property<int>("BoardSizeX")
                        .HasColumnType("int");

                    b.Property<int>("BoardSizeY")
                        .HasColumnType("int");

                    b.Property<int>("EShipTouchRule")
                        .HasColumnType("int");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("GameConfigId");

                    b.ToTable("GameConfigs");
                });

            modelBuilder.Entity("Domain.Ship", b =>
                {
                    b.Property<int>("ShipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipId"), 1L, 1);

                    b.Property<string>("Coordinates")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("GameBoardId")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("ShipId");

                    b.HasIndex("GameBoardId");

                    b.ToTable("Ship");
                });

            modelBuilder.Entity("Domain.ShipConfig", b =>
                {
                    b.Property<int>("ShipConfigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipConfigId"), 1L, 1);

                    b.Property<int>("GameConfigId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("ShipSizeX")
                        .HasColumnType("int");

                    b.Property<int>("ShipSizeY")
                        .HasColumnType("int");

                    b.HasKey("ShipConfigId");

                    b.HasIndex("GameConfigId");

                    b.ToTable("ShipConfigs");
                });

            modelBuilder.Entity("Domain.ShipQuantity", b =>
                {
                    b.Property<int>("ShipQuantityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipQuantityId"), 1L, 1);

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShipConfigId")
                        .HasColumnType("int");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("ShipSizeX")
                        .HasColumnType("int");

                    b.Property<int>("ShipSizeY")
                        .HasColumnType("int");

                    b.HasKey("ShipQuantityId");

                    b.HasIndex("ShipConfigId");

                    b.ToTable("ShipQuantities");
                });

            modelBuilder.Entity("Domain.GameBoard", b =>
                {
                    b.HasOne("Domain.GameConfig", "GameConfig")
                        .WithMany("GameBoards")
                        .HasForeignKey("GameConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameConfig");
                });

            modelBuilder.Entity("Domain.Ship", b =>
                {
                    b.HasOne("Domain.GameBoard", "GameBoard")
                        .WithMany("Ships")
                        .HasForeignKey("GameBoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameBoard");
                });

            modelBuilder.Entity("Domain.ShipConfig", b =>
                {
                    b.HasOne("Domain.GameConfig", "GameConfig")
                        .WithMany("ShipConfigs")
                        .HasForeignKey("GameConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameConfig");
                });

            modelBuilder.Entity("Domain.ShipQuantity", b =>
                {
                    b.HasOne("Domain.ShipConfig", "ShipConfig")
                        .WithMany("ShipQuantities")
                        .HasForeignKey("ShipConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShipConfig");
                });

            modelBuilder.Entity("Domain.GameBoard", b =>
                {
                    b.Navigation("Ships");
                });

            modelBuilder.Entity("Domain.GameConfig", b =>
                {
                    b.Navigation("GameBoards");

                    b.Navigation("ShipConfigs");
                });

            modelBuilder.Entity("Domain.ShipConfig", b =>
                {
                    b.Navigation("ShipQuantities");
                });
#pragma warning restore 612, 618
        }
    }
}
