using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CapacitorWebApplication.Models;

namespace CapacitorWebApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161123194334_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CapacitorWebApplication.Models.Resin", b =>
                {
                    b.Property<int>("ResinId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ResinId");

                    b.ToTable("Resins");
                });
        }
    }
}
