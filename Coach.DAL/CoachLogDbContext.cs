using Coach.DAL.Configurations;
using Coach.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coach.DAL
{
    public class CoachLogDbContext : DbContext
    {
        public CoachLogDbContext(DbContextOptions<CoachLogDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<CoachEntity> Coaches { get; set; }
        public DbSet<SportsmenEntity> Sportsmens { get; set; }
        public DbSet<GroupEntity> Gruops { get; set; }
        //public DbSet<LessonEntity> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CoachConfiguration());
            modelBuilder.ApplyConfiguration(new SportsmenConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }

    }
}
