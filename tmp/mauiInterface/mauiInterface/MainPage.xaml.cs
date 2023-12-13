using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using LibDing;
using System.ComponentModel;

namespace mauiInterface
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private string _authorInput;
        public string AuthorInput
        {
            get { return _authorInput; }
            set
            {
                if (_authorInput != value)
                {
                    _authorInput = value;
                    OnPropertyChanged(nameof(AuthorInput));
                }
            }
        }
        private DateTime _dateInput;
        public DateTime DateInput
        {
            get { return _dateInput; }
            set
            {
                if (_dateInput != value)
                {
                    _dateInput = value;
                    OnPropertyChanged(nameof(DateInput));
                }
            }
        }

        private string _nameInput;
        public string NameInput
        {
            get { return _nameInput; }
            set
            {
                if (_nameInput != value)
                {
                    _nameInput = value;
                    OnPropertyChanged(nameof(NameInput));
                }
            }
        }
        public QuoteBook quoteBook;
        private readonly ApiService _apiService;
        public MainPage()
        {
            InitializeComponent();
            this.quoteBook = new QuoteBook();
            _apiService = new ApiService();
            this.BindingContext = this;
        }
        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDataStore store = new MySqlDataStore();
                var quotes = await store.GetAllQuotesAsync();
                Testinglbl.Text = quotes.Count.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error making API call: {ex}");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.AuthorInput) && !string.IsNullOrEmpty(this.NameInput))
            {
                Quote newQuote = new Quote
                {
                    Author = this.AuthorInput,
                    Content = this.NameInput,
                    QuoteDate = this.DateInput
                };
                MySqlDataStore store = new MySqlDataStore();
                // Assuming you have a method to add a quote to your QuoteList
                store.AddQuoteAsync(newQuote);

                Testinglbl.Text = $"Added quote from {this.AuthorInput}";
            }
            else
            {
                Testinglbl.Text = "Author or Quote text cannot be empty";
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QuotesPage());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            MySqlDataStore store = new MySqlDataStore();
            await store.GenerateRandomQuotes();
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            MySqlDataStore store = new MySqlDataStore();
            await store.DeleteAllQuotesAsync();
        }
    }
    }
