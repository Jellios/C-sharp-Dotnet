using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using LibDing;
    

namespace mauiInterface
{
    public partial class MainPage : ContentPage
    {
        public QuoteBook quoteBook;
        private readonly ApiService _apiService;
        public MainPage()
        {
            InitializeComponent();
            this.quoteBook = new QuoteBook();
            _apiService = new ApiService();
        }
        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                var quotes = await _apiService.GetAsync<List<Quote>>("http://172.20.0.2:5233/quotes");
                // Do something with the quotes

                Testinglbl.Text = quotes.Count.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error making API call: {ex}");
            }
        }
    }
    }
