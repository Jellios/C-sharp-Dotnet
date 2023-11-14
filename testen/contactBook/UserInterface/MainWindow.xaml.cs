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
using contacts; 

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

         ContactBook contactBook;
        public MainWindow()
        {
            InitializeComponent();
            FirstName.Width=100;
            LastName.Width=100;
            PhoneNumber.Width=100;
            
          //   Contact contact = new Contact("John", "Doe", "1234567890"); 

          contactBook =new ContactBook();
          AddContactButton.Click +=AddContact;
        }
        public void AddContact(object sender, RoutedEventArgs e)
        {
            if (FirstName.Text != "" && LastName.Text != "" && PhoneNumber.Text != "")
            {
                Contact c = new Contact(FirstName.Text, LastName.Text, PhoneNumber.Text);
                this.contactBook.AddContact(c);
                
                MyList.Items.Add(c);
            }
        }
        
    }
}
