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


