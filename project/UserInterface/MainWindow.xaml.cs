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
        private readonly ApiService _apiService;
        public MainWindow()
        {
            InitializeComponent();
            this.quoteBook = new QuoteBook();
            _apiService = new ApiService();
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(async () =>
            {
                var quotes = await _apiService.GetAsync<List<Quote>>("http://localhost:5233/quotes");
                // Do something with the quotes

                Dispatcher.Invoke(() =>
                {
                    Testinglbl.Content = quotes.Count.ToString();
                });
            });
        }

    }
}
