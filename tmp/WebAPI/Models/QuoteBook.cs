using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class QuoteBook
{
    private List<Quote> qoutesList;

    public List<Quote> QuotesList {
        get {return this.qoutesList;}
        set {this.qoutesList = value;}
    }

    public QuoteBook()
    {
        this.qoutesList = new List<Quote>();
    }
    public void AddQuote(Quote quote)
    {
        quote.Id = this.qoutesList.Count();
        this.qoutesList.Add(quote);
        
    }
    public void RemoveQuote(int x)
    {
        if (this.qoutesList.Count > x)
        {
            this.qoutesList.RemoveAt(x);
        }
    }
    public void EditQuote(Quote quote, int x)
    {
        if (this.qoutesList.Count > x)
        {
            this.qoutesList[x] = quote;
        }
    }
    public Quote GetQuote(int x)
    {
        if (this.qoutesList.Count > x)
        {
            return this.qoutesList[x];
        }
        else
        {
            return new Quote();
        }
    }
}
}