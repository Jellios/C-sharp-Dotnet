using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibDing;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public QuoteBook quoteBook;

        public MainWindow()
        {
            InitializeComponent();
            this.quoteBook = new QuoteBook();
            
        }
        public void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string author = AuthorInput.Text;
            DateTime date = DateInput.SelectedDate.Value;
            string quoteText = QuoteTextInput.Text;

            if (author != "" && date != DateTime.MinValue && quoteText != "" )
            {
                Quote quote = new Quote(author,quoteText,date);
                this.quoteBook.AddQuote(quote);
                Testinglbl.Content = "Werkende";
            }
        }
    }
}
