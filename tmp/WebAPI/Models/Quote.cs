using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebAPI.Models
{
    public class Quote
{
    [Key]
    [Column("QuoteID")]
    public int Id { get; set; }

    [Column("QuoteAuthor")]
    public string Author { get; set; }

    [Column("QuoteText")]
    public string Content { get; set; }

    [Column("QuoteDate")]
    public DateTime QuoteDate { get; set; }

    public Quote()
    {
        this.QuoteDate = new DateTime();
        this.Author = "";
        this.Content = "";
    }
    public Quote(string _author, string _content, DateTime _quoteDate)
    {
        this.Author = _author;
        this.Content = _content;
        this.QuoteDate = _quoteDate;
    }
}
}