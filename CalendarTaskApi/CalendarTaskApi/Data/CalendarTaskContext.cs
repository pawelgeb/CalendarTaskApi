using CalendarTaskApi.Models;
using Microsoft.EntityFrameworkCore;


namespace CalendarTaskApi.Data
{
    public class CalendarTaskContext : DbContext
    {
        public CalendarTaskContext(DbContextOptions<CalendarTaskContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=postgresCalendar;Username=postgres;Password=mysecretpassword");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalendarTask>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
        }
        public virtual DbSet<CalendarTask> Tasks { get; set; }
    }
}

