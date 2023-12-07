using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
 public class MockRepo
{
    public List<Quote> list = new List<Quote>
    {
        new Quote { Id = 1, Author = "Author 1", Content = "Quote 1", QuoteDate = DateTime.Now.AddDays(-10) },
        new Quote { Id = 2, Author = "Author 2", Content = "Quote 2", QuoteDate = DateTime.Now.AddDays(-9) },
        new Quote { Id = 3, Author = "Author 3", Content = "Quote 3", QuoteDate = DateTime.Now.AddDays(-8) },
        new Quote { Id = 4, Author = "Author 4", Content = "Quote 4", QuoteDate = DateTime.Now.AddDays(-7) },
        new Quote { Id = 5, Author = "Author 5", Content = "Quote 5", QuoteDate = DateTime.Now.AddDays(-6) }
    };
    public MockRepo()
    {
        
    }
    public IEnumerable<Quote> GetAllQuotes()
    {
        return list;
    }
}
}