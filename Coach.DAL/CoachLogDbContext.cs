﻿using Coach.DAL.Configurations;
using Coach.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coach.DAL
{
    public class CoachLogDbContext : DbContext
    {
        public CoachLogDbContext(DbContextOptions<CoachLogDbContext> options) : base(options)
        {           
            Database.EnsureCreated();
        }

        public DbSet<CoachEntity> Coaches { get; set; }
        public DbSet<SportsmenEntity> Sportsmens { get; set; }
        //public DbSet<GruopEntity> Gruops { get; set; }
        //public DbSet<LessonEntity> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CoachConfiguration());
            modelBuilder.ApplyConfiguration(new SportsmenConfiguration());
        }

    }
}
