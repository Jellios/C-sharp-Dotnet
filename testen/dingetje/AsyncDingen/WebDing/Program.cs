using System;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Parser;

class Program
{
 static async Task Main(string[] args)
 {
     string url = "https://geekinho.xyz/?encoded_value=LF4LQ&sub1=1d535cf610b54c3ea2526632fe5be17e&sub2=&sub3=&sub4=&sub5=11263&source_id=2313";
     await Crawl(url);
 }

 static async Task Crawl(string url)
 {
     var config = Configuration.Default.WithDefaultLoader();
     var context = BrowsingContext.New(config);
     var document = await context.OpenAsync(url);

     foreach (var link in document.Links)
     {
        try
        {
string href = link.GetAttribute("href");
         Console.WriteLine(href);
         await Crawl(href);
        }
        catch
        {

        }
         
     }
 }
}
