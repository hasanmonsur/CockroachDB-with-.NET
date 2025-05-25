using CockroachDBApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CockroachDBApi.Data
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options)
            : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");
                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.Balance)
                      .HasColumnName("balance");
            });
        }
    }
}
