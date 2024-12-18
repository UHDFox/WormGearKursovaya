﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WormGearKursovaya;

#nullable disable

namespace WormGearKursovaya.Migrations
{
    [DbContext(typeof(DbManager))]
    [Migration("20241205174731_AddConstructionUnitAndDetailEntities")]
    partial class AddConstructionUnitAndDetailEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WormGearKursovaya.ConstructionUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Aw")
                        .HasColumnType("double precision");

                    b.Property<double>("Kfl")
                        .HasColumnType("double precision");

                    b.Property<double>("N")
                        .HasColumnType("double precision");

                    b.Property<double>("X")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("ConstructionUnits");
                });

            modelBuilder.Entity("WormGearKursovaya.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Aw")
                        .HasColumnType("double precision");

                    b.Property<int?>("ConstructionUnitId")
                        .HasColumnType("integer");

                    b.Property<double>("Kfl")
                        .HasColumnType("double precision");

                    b.Property<double>("M")
                        .HasColumnType("double precision");

                    b.Property<double>("N")
                        .HasColumnType("double precision");

                    b.Property<double>("N1")
                        .HasColumnType("double precision");

                    b.Property<double>("SigmaHP")
                        .HasColumnType("double precision");

                    b.Property<double>("T2")
                        .HasColumnType("double precision");

                    b.Property<double>("X")
                        .HasColumnType("double precision");

                    b.Property<double>("Z1")
                        .HasColumnType("double precision");

                    b.Property<int>("Z2")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ConstructionUnitId");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("WormGearKursovaya.Detail", b =>
                {
                    b.HasOne("WormGearKursovaya.ConstructionUnit", "ConstructionUnit")
                        .WithMany("Details")
                        .HasForeignKey("ConstructionUnitId");

                    b.Navigation("ConstructionUnit");
                });

            modelBuilder.Entity("WormGearKursovaya.ConstructionUnit", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
