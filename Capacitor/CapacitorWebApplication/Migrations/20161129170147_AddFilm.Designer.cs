using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CapacitorWebApplication.Models;

namespace CapacitorWebApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161129170147_AddFilm")]
    partial class AddFilm
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

                    b.Property<int?>("FilmTypeId");

                    b.Property<double>("HoldTime");

                    b.Property<string>("StampCapSerialNumber");

                    b.Property<int>("StepsToZeroCap");

                    b.Property<int>("VatZeroCap");

                    b.HasKey("Id");

                    b.HasIndex("FilmTypeId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("CapacitorWebApplication.Models.FilmType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FilmTypes");
                });

            modelBuilder.Entity("CapacitorWebApplication.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FilmId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("CapacitorWebApplication.Models.Resin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FilmId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("Resins");
                });

            modelBuilder.Entity("CapacitorWebApplication.Models.Film", b =>
                {
                    b.HasOne("CapacitorWebApplication.Models.FilmType", "FilmType")
                        .WithMany()
                        .HasForeignKey("FilmTypeId");
                });

            modelBuilder.Entity("CapacitorWebApplication.Models.Material", b =>
                {
                    b.HasOne("CapacitorWebApplication.Models.Film")
                        .WithMany("Materials")
                        .HasForeignKey("FilmId");
                });

            modelBuilder.Entity("CapacitorWebApplication.Models.Resin", b =>
                {
                    b.HasOne("CapacitorWebApplication.Models.Film")
                        .WithMany("Resins")
                        .HasForeignKey("FilmId");
                });
        }
    }
}
