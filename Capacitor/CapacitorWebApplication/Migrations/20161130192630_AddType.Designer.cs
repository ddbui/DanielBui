using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CapacitorWebApplication.Models;

namespace CapacitorWebApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161130192630_AddType")]
    partial class AddType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CapacitorWebApplication.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("FilmThickness");

                    b.Property<int?>("FilmType");

                    b.Property<double>("HoldTime");

                    b.Property<string>("StampCapSerialNumber");

                    b.Property<int>("StepsToZeroCap");

                    b.Property<int>("VatZeroCap");

                    b.HasKey("Id");

                    b.HasIndex("FilmType");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("CapacitorWebApplication.Models.FilmMaterial", b =>
                {
                    b.Property<int>("FilmId");

                    b.Property<int>("MaterialId");

                    b.HasKey("FilmId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("FilmMaterial");
                });

            modelBuilder.Entity("CapacitorWebApplication.Models.FilmResin", b =>
                {
                    b.Property<int>("FilmId");

                    b.Property<int>("ResinId");

                    b.HasKey("FilmId", "ResinId");

                    b.HasIndex("ResinId");

                    b.ToTable("FilmResin");
                });

            modelBuilder.Entity("CapacitorWebApplication.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("CapacitorWebApplication.Models.Resin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Resins");
                });

            modelBuilder.Entity("CapacitorWebApplication.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("CapacitorWebApplication.Models.Film", b =>
                {
                    b.HasOne("CapacitorWebApplication.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("FilmType");
                });

            modelBuilder.Entity("CapacitorWebApplication.Models.FilmMaterial", b =>
                {
                    b.HasOne("CapacitorWebApplication.Models.Film", "Film")
                        .WithMany("FilmMaterials")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CapacitorWebApplication.Models.Material", "Material")
                        .WithMany("FilmMaterials")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CapacitorWebApplication.Models.FilmResin", b =>
                {
                    b.HasOne("CapacitorWebApplication.Models.Film", "Film")
                        .WithMany("FilmResins")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CapacitorWebApplication.Models.Resin", "Resin")
                        .WithMany("FilmResins")
                        .HasForeignKey("ResinId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
