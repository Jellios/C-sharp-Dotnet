using System.Globalization;
using System;
using contacts;
using System.ComponentModel;
namespace YourConsoleAppNamespace
{
    class Program
    {
        public static List<Contact> contactsList;
       public static void FunctionalityTest() {
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


        public static void PrintContactInfo(Contact c)
        {
            Console.WriteLine($"Contact information:\nFirstName: {c.FirstName},\nLastName: {c.LastName},\nPhoneNumber: {c.PhoneNumber}");
        }
        public static void LoopContactList(ref List<Contact> lst)
        {
            foreach (Contact c in lst)
            {
                PrintContactInfo(c);
            }
        }
       public static void AddContact(ref List<Contact> lst) {
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
        public static void RemoveContact()
        {
            
        }
        public static int getChoice()
        {
           
            string str ="";
            int z = -1;
            bool isOk = false;
            List<string> choices = new List<string>();
            choices.Add("Add contact");
            choices.Add("Stop");

            do
            {
                System.Console.WriteLine("Enter your choice: ");
                for (int i = 0; i < choices.Count(); i++)
                {
                    System.Console.WriteLine($"[{i}]\t{choices[i]}");
                }
                System.Console.Write("Your choice: ");
                str = Console.ReadLine();
                try
                {
                    z = Convert.ToInt32(str);
                    if (z < 0 || z > choices.Count())
                    {
                        System.Console.WriteLine("Not a valid option, enter a number from the list");
                    }
                    else
                    {
                        isOk = true;
                    }
                }
                catch (Exception e)
                {
                   
                    if (e.GetType().ToString() == "System.FormatException")
                    {
                        System.Console.WriteLine("Not a Number! please enter a valid choice!");
                    }
                }
            } while(!isOk);

            return z;
            

        }
        public static void Menu()
        {
            do
            {
                int x = getChoice();
                switch(x)
                {
                    case 0:
                        AddContact(ref contactsList);
                        break;
                }
            }while(true);
        }
      public  static void Main(string[] args)
        {
         contactsList  = new List<Contact>();
           Menu();
           //  AddContact(ref contactsList);
           // AddContact(ref contactsList);
           // LoopContactList(ref contactsList);
        }
    }
}