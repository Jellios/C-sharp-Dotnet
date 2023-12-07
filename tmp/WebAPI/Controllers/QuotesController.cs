using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Models;

namespace WebAPI.Controllers
{
   [ApiController]
[Route("[controller]")]
public class QuotesController : ControllerBase
{
    private readonly QuoteRepository _quoteRepository;

    public QuotesController(QuoteRepository quoteRepository)
    {
        _quoteRepository = quoteRepository;
    }

   [HttpPost]
public async Task<IActionResult> AddQuote([FromBody] Quote quote)
{
    System.Console.WriteLine("quotes controller, add quote");
    System.Console.WriteLine("teeest");
    if (quote.Author != "" && quote.QuoteDate != DateTime.MinValue && quote.Content != "")
    {
        await _quoteRepository.AddQuoteAsync(quote);
        return Ok(new { message = "Quote added successfully!" });
    }
    else
    {
        return BadRequest(new { message = "Please fill in all fields." });
    }
}

    [HttpGet]
    public async Task<IActionResult> GetAllQuotes()
    {
        var quotes = await _quoteRepository.GetQuotesAsync();
        return Ok(quotes);
    }
}
}