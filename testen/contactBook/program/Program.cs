using System.Globalization;
using System;
using contacts;
using System.ComponentModel;
namespace YourConsoleAppNamespace
{
    class Program
    {
        void FunctionalityTest() {
            // Create a new Contact instance
            Contact contact = new Contact("John", "Doe", "1234567890");

            // Access and modify the properties
            Console.WriteLine($"First Name: {contact.FirstName}");
            Console.WriteLine($"Last Name: {contact.LastName}");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");

            contact.FirstName = "Jane";
            contact.LastName = "Smith";
            contact.PhoneNumber = "9876543210";

            Console.WriteLine($"Updated First Name: {contact.FirstName}");
            Console.WriteLine($"Updated Last Name: {contact.LastName}");
            Console.WriteLine($"Updated Phone Number: {contact.PhoneNumber}");

            // Wait for user input before closing the console window
            Console.ReadLine();
        }


        public void PrintContactInfo(Contact c)
        {
            Console.WriteLine($"Contact information:\nFirstName: {c.FirstName},\nLastName: {c.LastName},\nPhoneNumber: {c.PhoneNumber}");
        }
        public void LoopContactList(ref List<Contact> lst)
        {
            foreach (Contact c in lst)
            {
                PrintContactInfo(c);
            }
        }
       public void AddContact(ref List<Contact> lst) {
            Contact c = new Contact();
            string tmp = "";
            do{
                Console.Write("Enter Contact First name: ");
                tmp = Console.ReadLine();
                if (tmp == "")
                {
                    Console.WriteLine("Invallid input! try again");
                }
            } while(tmp == "");
            c.FirstName = tmp;
            tmp = "";

            do{
                Console.Write("Enter Contact Last name: ");
                tmp = Console.ReadLine();
                if (tmp == "")
                {
                    Console.WriteLine("Invallid input! try again");
                }
            } while(tmp == "");
            c.LastName = tmp;
            tmp = ""; 
             do{
                Console.Write("Enter Contact Phone number: ");
                tmp = Console.ReadLine();
                if (tmp == "")
                {
                    Console.WriteLine("Invallid input! try again");
                }
            } while(tmp == "");
            c.PhoneNumber = tmp;
            lst.Add(c);
           
        }
      public  static void Main(string[] args)
        {
            List<Contact> contactsList = new List<Contact>();
             Program program = new Program();
             program.AddContact(ref contactsList);
            program.AddContact(ref contactsList);
            program.LoopContactList(ref contactsList);
        }
    }
}