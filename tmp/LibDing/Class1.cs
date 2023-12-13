namespace LibDing;

public class Class1
{

}
public class Quote
{
    private int id;


    private string author;
    private string content;

    private DateTime quoteDate;

    public string Author {get; set;}

    public int Id {get; set;}
    public string Content {get; set;}

    public DateTime QuoteDate {get; set;}

    public Quote()
    {
        this.quoteDate = new DateTime();
        this.author = "";
        this.content = "";
        this.id = 0;
    }
    public Quote(string _author, string _content, DateTime _quoteDate, int _id)
    {
        this.author = _author;
        this.content = _content;
        this.quoteDate = _quoteDate;
        this.id = _id;
    }
}
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
