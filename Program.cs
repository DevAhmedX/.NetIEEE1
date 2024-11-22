using System;
using System.Collections.Generic;
using System.Linq;

public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName}, Phone: {PhoneNumber}";
    }
}

public interface IContactManager
{
    void AddContact(string firstName, string lastName, string phoneNumber);
    void EditContact(string phoneNumber, string newFirstName, string newLastName, string newPhoneNumber);
    void DeleteContact(string phoneNumber);
    IEnumerable<User> GetAllContacts();
}

public class ContactManager : IContactManager
{
    private readonly ICollection<User> contacts;

    public ContactManager()
    {
        contacts = new List<User>();
    }

    public void AddContact(string firstName, string lastName, string phoneNumber)
    {
        if (contacts.Any(c => c.PhoneNumber == phoneNumber))
        {
            Console.WriteLine("Error: A contact with this phone number already exists.");
            return;
        }

        contacts.Add(new User
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber
        });

        Console.WriteLine("Contact added successfully.");
    }

    public void EditContact(string phoneNumber, string newFirstName, string newLastName, string newPhoneNumber)
    {
        var user = contacts.FirstOrDefault(c => c.PhoneNumber == phoneNumber);

        if (user == null)
        {
            Console.WriteLine("Error: Contact not found.");
            return;
        }

        if (!string.IsNullOrWhiteSpace(newPhoneNumber) &&
            contacts.Any(c => c.PhoneNumber == newPhoneNumber && c.PhoneNumber != phoneNumber))
        {
            Console.WriteLine("Error: A contact with the new phone number already exists.");
            return;
        }

        user.FirstName = newFirstName ?? user.FirstName;
        user.LastName = newLastName ?? user.LastName;
        user.PhoneNumber = string.IsNullOrWhiteSpace(newPhoneNumber) ? user.PhoneNumber : newPhoneNumber;

        Console.WriteLine("Contact updated successfully.");
    }

    public void DeleteContact(string phoneNumber)
    {
        var user = contacts.FirstOrDefault(c => c.PhoneNumber == phoneNumber);

        if (user == null)
        {
            Console.WriteLine("Error: Contact not found.");
            return;
        }

        contacts.Remove(user);
        Console.WriteLine("Contact deleted successfully.");
    }

    public IEnumerable<User> GetAllContacts()
    {
        return contacts.OrderBy(c => c.FirstName).ThenBy(c => c.LastName);
    }
}

class Program
{
    static void Main()
    {
        IContactManager contactManager = new ContactManager();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Display All Contacts");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter First Name: ");
                    var firstName = Console.ReadLine();
                    Console.Write("Enter Last Name: ");
                    var lastName = Console.ReadLine();
                    Console.Write("Enter Phone Number: ");
                    var phoneNumber = Console.ReadLine();
                    contactManager.AddContact(firstName, lastName, phoneNumber);
                    break;

                case "2":
                    Console.Write("Enter Current Phone Number: ");
                    var currentPhoneNumber = Console.ReadLine();
                    Console.Write("Enter New First Name (press Enter to skip): ");
                    var newFirstName = Console.ReadLine();
                    Console.Write("Enter New Last Name (press Enter to skip): ");
                    var newLastName = Console.ReadLine();
                    Console.Write("Enter New Phone Number (press Enter to skip): ");
                    var newPhoneNumber = Console.ReadLine();
                    contactManager.EditContact(
                        currentPhoneNumber,
                        string.IsNullOrWhiteSpace(newFirstName) ? null : newFirstName,
                        string.IsNullOrWhiteSpace(newLastName) ? null : newLastName,
                        string.IsNullOrWhiteSpace(newPhoneNumber) ? null : newPhoneNumber);
                    break;

                case "3":
                    Console.Write("Enter Phone Number to Delete: ");
                    var phoneToDelete = Console.ReadLine();
                    contactManager.DeleteContact(phoneToDelete);
                    break;

                case "4":
                    Console.WriteLine("All Contacts:");
                    foreach (var contact in contactManager.GetAllContacts())
                    {
                        Console.WriteLine(contact);
                    }
                    break;

                case "5":
                    isRunning = false;
                    Console.WriteLine("Exiting program.");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
