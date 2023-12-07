using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
public class QuoteRepository
{
    private readonly QuoteContext _context;

    public QuoteRepository(QuoteContext context)
    {
        _context = context;
    }

    public async Task<List<Quote>> GetQuotesAsync()
    {
        return await _context.Quotes.ToListAsync();
    }

    public async Task<Quote> GetQuoteAsync(int id)
    {
        return await _context.Quotes.FindAsync(id);
    }

    public async Task AddQuoteAsync(Quote quote)
    {
         System.Console.WriteLine("quotes repository, add quote");
        _context.Quotes.Add(quote);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateQuoteAsync(Quote quote)
    {
        _context.Entry(quote).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteQuoteAsync(int id)
    {
        var quote = await _context.Quotes.FindAsync(id);
        _context.Quotes.Remove(quote);
        await _context.SaveChangesAsync();
    }
}

}
