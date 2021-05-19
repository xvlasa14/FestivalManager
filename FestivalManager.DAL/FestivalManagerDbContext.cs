using FestivalManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace FestivalManager.DAL
{
    public class FestivalManagerDbContext : DbContext
    {
        public FestivalManagerDbContext(DbContextOptions<FestivalManagerDbContext> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<Band> Bands { get; set; } = null!;
        public DbSet<Stage> Stages { get; set; } = null!;
        public DbSet<Slot> Slots { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>()
                .HasMany(b => b.Slots)
                .WithOne(s => s.Band)
                .HasForeignKey(s => s.BandId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Stage>()
                .HasMany(s=> s.Slots)
                .WithOne(s => s.Stage)
                .HasForeignKey(s=> s.StageId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

    }
}
