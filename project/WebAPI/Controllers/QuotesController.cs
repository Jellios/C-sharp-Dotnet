using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Models;
using WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
   [ApiController]
[Route("api/[controller]")]
public class QuotesController : ControllerBase
{
   // private readonly QuoteRepository _quoteRepository;

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
   public ActionResult GetAllQuotes(){
    return Ok(_quoteRepository.GetAllQuotes());
   }
   [HttpGet("{id}")]
public async Task<ActionResult<Quote>> GetQuote(int id)
{
    var quote = await _quoteRepository.GetQuoteAsync(id);

    if (quote == null)
    {
        return NotFound();
    }

    return quote;
}
[HttpPut("{id}")]
public async Task<IActionResult> UpdateQuote(int id, [FromBody] Quote quote)
{
    if (id != quote.Id)
    {
        return BadRequest();
    }

    try
    {
        await _quoteRepository.UpdateQuoteAsync(quote);
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!QuoteExists(id))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }

    return NoContent();
}

private bool QuoteExists(int id)
{
    return _quoteRepository.GetQuoteAsync(id) != null;
}
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteQuote(int id)
{
    var quote = await _quoteRepository.GetQuoteAsync(id);
    if (quote == null)
    {
        return NotFound();
    }

    await _quoteRepository.DeleteQuoteAsync(id);
    return NoContent();
}
}
}