using LibDing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mauiInterface
{
    public partial class QuotesPage: ContentPage
    {

        public QuotesPage() {
            InitializeComponent();
           // BindingContext = ((MainPage)Application.Current.MainPage).BindingContext;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            MySqlDataStore store = new MySqlDataStore();
            var quotes = await store.GetAllQuotesAsync();
            QuotesListView.ItemsSource = quotes;
            
        }
        private void EditButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var quote = button.CommandParameter as Quote;
            Console.WriteLine("#####################");
            Console.WriteLine($"{quote.Id}, {quote.Content}");
            Console.WriteLine("#####################");
            tmpLabel.Text = quote.Content;
            // Navigate to the edit page with the selected quote
            Navigation.PushAsync(new EditQuotePage(quote));
        }
        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var quote = button.CommandParameter as Quote;
            MySqlDataStore store = new MySqlDataStore();
            await store.DeleteQuoteAsync(quote);
            var quotes = await store.GetAllQuotesAsync();
            QuotesListView.ItemsSource = quotes;
            // Delete the selected quote
        }
    }
}
