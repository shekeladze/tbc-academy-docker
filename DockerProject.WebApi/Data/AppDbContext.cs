using Microsoft.EntityFrameworkCore;

namespace DockerProject.WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Person>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired(true);

            modelBuilder.Entity<Person>()
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired(true);

            modelBuilder.Entity<Person>()
                .Property(p => p.DateOfBirth)
                .IsRequired(true);
        }
    }
}
