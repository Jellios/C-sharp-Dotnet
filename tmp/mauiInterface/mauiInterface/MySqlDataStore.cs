using LibDing;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mauiInterface
{
     class MySqlDataStore : IDataStore
    {
        public List<Quote> QuoteList { get; set; }

        private string serverIpDing = "http://localhost";
        public async Task<Quote> GetQuoteAsync(Quote quote)
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(serverIpDing + ":5233/api/Quotes/" + quote.Id);
            Console.Out.WriteLineAsync("HTTPClient response: " + response);
            return JsonConvert.DeserializeObject<Quote>(response);
        }
        public async Task AddQuoteAsync(Quote quote)
        {
            HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(quote), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(serverIpDing + ":5233/api/Quotes", content);
            response.EnsureSuccessStatusCode();
            Console.Out.WriteLineAsync("HTTPClient response: " + await response.Content.ReadAsStringAsync());
        }

        public  async Task<List<Quote>> GetAllQuotesAsync()
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(serverIpDing +":5233/api/Quotes");
            Console.Out.WriteLineAsync("HTTPClient response: " + response);
            return JsonConvert.DeserializeObject<List<Quote>>(response);
        }
        public async Task UpdateQuoteAsync(Quote quote)
        {
            HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(quote), Encoding.UTF8, "application/json");
            var response = await client.PutAsync(serverIpDing + ":5233/api/Quotes/" + quote.Id, content);
            response.EnsureSuccessStatusCode();
            Console.Out.WriteLineAsync("HTTPClient response: " + await response.Content.ReadAsStringAsync());
        }
        public async Task DeleteQuoteAsync(Quote quote)
        {
            HttpClient client = new HttpClient();
            var response = await client.DeleteAsync(serverIpDing + ":5233/api/Quotes/" + quote.Id);
            response.EnsureSuccessStatusCode();
            Console.Out.WriteLineAsync("HTTPClient response: " + await response.Content.ReadAsStringAsync());
        }
        public async Task GenerateRandomQuotes()
        {
            var random = new Random();
            var store = new MySqlDataStore();

            for (int i = 0; i < 100; i++)
            {
                var quote = new Quote
                {
                    Author = i.ToString(),
                    Content = GetRandomString(10, random),
                    QuoteDate = DateTime.Now
                };
                await Console.Out.WriteLineAsync($"{i}");
                await store.AddQuoteAsync(quote);
            }
        }

        private string GetRandomString(int length, Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public async Task DeleteAllQuotesAsync()
        {
            // Get all quotes
            var quotes = await GetAllQuotesAsync();

            // Delete each quote
            foreach (var quote in quotes)
            {
                await DeleteQuoteAsync(quote);
            }
        }


    }
}
