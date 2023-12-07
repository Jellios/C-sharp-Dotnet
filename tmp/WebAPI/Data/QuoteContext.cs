using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

public class QuoteContext : DbContext
{
    public QuoteContext(DbContextOptions<QuoteContext> options)
        : base(options)
    {
    }

    public DbSet<Quote> Quotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quote>().ToTable("quote");
    }
}