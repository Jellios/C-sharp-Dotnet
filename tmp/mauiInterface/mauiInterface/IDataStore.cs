using LibDing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mauiInterface
{
    public interface IDataStore
    {
        List<Quote> QuoteList { get; set; }
        Task<List<Quote>> GetAllQuotesAsync();
        Task  AddQuoteAsync(Quote quote);
        Task DeleteQuoteAsync(Quote quote);
        Task UpdateQuoteAsync(Quote quote);
        Task<Quote> GetQuoteAsync(Quote quote);
    }
}
