using System.Collections.Generic;

namespace contacts;

    public class Contact
    {
        string firstName;
        string lastName;

        string phoneNumber;

        public Contact(string _firstName, string _lastName, string _phoneNumber)
        {
            this.firstName = _firstName;
            this.lastName = _lastName;
            this.phoneNumber = _phoneNumber;
        }
        public Contact()
        {
            this.firstName = "";
            this.lastName = "";
            this.phoneNumber = "";
        }

        public string FirstName {
            get{return firstName;}
            set {firstName = value;}
        }
        public string LastName {
            get{return lastName;}
            set {lastName = value;}
        }
        public string PhoneNumber {
            get{return phoneNumber;}
            set {phoneNumber = value;}
        }
    }
    public class ContactBook: Contact
    {
        List<Contact> contList;

        public List<Contact> ContactList {
            get { return contList;}
        }
        public void AddContact(Contact c)
        {
            this.contList.Add(c);
        }
        public void RemoveContact(int x)
        {
            this.contList.RemoveAt(x);
        }
        public void AlterContact(int x, Contact c)
        {
            this.contList[x] = c;
        }
        public ContactBook()
        {
            this.contList = new List<Contact>();
        }
    }


