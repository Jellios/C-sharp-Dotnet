using Microsoft.EntityFrameworkCore;
using WebAPI.Models;



namespace WebAPI.Contexts
{
public class QuoteContext : DbContext
{
    public QuoteContext(DbContextOptions<QuoteContext> opt)
        : base(opt)
    {
    }

    public DbSet<Quote> Quotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quote>().ToTable("quote");
    }
}
}