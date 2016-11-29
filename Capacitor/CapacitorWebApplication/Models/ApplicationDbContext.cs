﻿using Microsoft.EntityFrameworkCore;

namespace CapacitorWebApplication.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options) { }
        public DbSet<Resin> Resins { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<FilmType> FilmTypes { get; set; }

        public DbSet<Film> Films { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmResin>().HasKey(t => new { t.FilmId, t.ResinId });

            modelBuilder.Entity<FilmResin>()
                .HasOne(pt => pt.Film)
                .WithMany(p => p.FilmResins)
                .HasForeignKey(pt => pt.FilmId);

            modelBuilder.Entity<FilmResin>()
                .HasOne(pt => pt.Resin)
                .WithMany(t => t.FilmResins)
                .HasForeignKey(pt => pt.ResinId);
        }
    }
}
