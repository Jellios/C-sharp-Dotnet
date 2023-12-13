using LibDing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mauiInterface
{
    public partial class EditQuotePage: ContentPage
    {
        public Quote _quote;

        public EditQuotePage(Quote quote) 
        {
            InitializeComponent();
            _quote = quote;
            AuthorEntry.Text = _quote.Author;
            DateEntry.Date = _quote.QuoteDate;
            QuoteTextEntry.Text = _quote.Content;
        }
        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            // Save the changes to the quote
            _quote.Author = AuthorEntry.Text;
            _quote.QuoteDate = DateEntry.Date;
            _quote.Content = QuoteTextEntry.Text;

            // Save the changes
            MySqlDataStore store = new MySqlDataStore();
            await store.UpdateQuoteAsync(_quote);

            // Navigate back to the previous page
            await Navigation.PopAsync();

        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
