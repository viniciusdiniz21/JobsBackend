using JobsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsBackend.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
                .HasOne(e => e.Company)
                .WithMany(e => e.Jobs)
                .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<Candidate>()
                .HasOne(e => e.Job)
                .WithMany(e => e.Candidates)
                .HasForeignKey(e => e.JobId);

            modelBuilder.Entity<Company>()
                .Property(e => e.CompanySize)
                .HasConversion<string>();

            modelBuilder.Entity<Job>()
               .Property(e => e.JobLevel)
               .HasConversion<string>();
        }
    }
}
