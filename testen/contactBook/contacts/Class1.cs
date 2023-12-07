using System.Collections.Generic;
using System.Globalization;

namespace contacts;

public class Person : Contact
{
    string firstName;
    string lastName;
    public Person(string _firstName, string _lastName, string _phoneNumber)
    {
        this.firstName = _firstName;
        this.lastName = _lastName;
        this.PhoneNumber = _phoneNumber;
    }
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
}
public abstract class Contact
{
   private string phoneNumber = "";

   public string PhoneNumber
   {
       get { return phoneNumber; }
       set { phoneNumber = value; }
   }
}
public class Business : Contact
{
    private string businessName;
    private string contactPersonName;

    public Business(string businessName, string phoneNumber, string contactPersonName)
    {
        this.businessName = businessName;
        this.PhoneNumber = phoneNumber;
        this.contactPersonName = contactPersonName;
    }

    public string BusinessName
    {
        get { return businessName; }
        set { businessName = value; }
    }

    public string ContactPersonName
    {
        get { return contactPersonName; }
        set { contactPersonName = value; }
    }
}

public class GenericContact<T> where T : Contact
{
    public T Contact { get; set; }
}
public class ContactBook
{
    List<GenericContact<Contact>> contList;

    public List<GenericContact<Contact>> ContactList
    {
        get { return contList; }
    }
   public void AddContact(Contact c)
{
   this.contList.Add(new GenericContact<Contact> { Contact = c });
}
    public void RemoveContact(int x)
    {
        this.contList.RemoveAt(x);
    }
    public void AlterContact(int x, Contact c)
    {
        this.contList[x] = new GenericContact<Contact> { Contact = c };
    }
    public ContactBook()
    {
        this.contList = new List<GenericContact<Contact>>();
    }
}


