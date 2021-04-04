using Microsoft.EntityFrameworkCore;


namespace MyDailyHerping.Models
{
    class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyDailyHerping.db;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .HasOne(a => a.Observation)
                .WithOne(o => o.Area)
                .HasForeignKey<Observation>(b => b.AreaID);
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Observation> Observations { get; set; }
    }
}
