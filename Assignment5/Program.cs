using System;
using System.Collections.Generic;
using Assignment5to7;
public class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Start();
    }

    public void Start()
    {
        Dictionary<string, LibraryItem> libraryItems = new Dictionary<string, LibraryItem>
        {
            { "978-9389647747", new Book("1984", "George Orwell", "978-9389647747") },
            { "978-0743273565", new Book("The Great Gatsby", "F. Scott Fitzgerald", "978-0743273565") },
            { "978-1430219491", new Book("Coders at Work", "Peter Seibel", "978-1430219491") },
            { "9781625272531", new Magazine("Tech Weekly", "Various", "9781625272531") }
        };

        DisplayLibraryItems(libraryItems);

        Person kevin = new Person("Kevin", 12345);
        Person susan = new Person("Susan", 98765);

        BorrowingManager manager = new BorrowingManager();

        manager.BorrowItem(libraryItems["978-9389647747"], kevin, new DateTime(2025, 12, 10));
        manager.BorrowItem(libraryItems["978-1430219491"], susan, new DateTime(2025, 10, 1)); // overdue example

        TrackLibraryItems(libraryItems, manager);

       
    }
    public void DisplayLibraryItems(Dictionary<string, LibraryItem> libraryItems)
    {
        foreach (var item in libraryItems.Values)
        {
            Console.WriteLine(item);
        }
    }
    public void TrackLibraryItems(Dictionary<string, LibraryItem> libraryItems, BorrowingManager manager)
    {
        List<LibraryItem> borrowed = manager.GetBorrowedItems(libraryItems);
        Console.WriteLine("Borrowed items:");
        foreach (var item in borrowed)
        {
            Console.WriteLine(item);
        }
        List<LibraryItem> overdue = manager.GetOverdueItems(libraryItems);
        Console.WriteLine("Overdue items:");
        foreach (var item in overdue)
        {
            Console.WriteLine(item);
        }
    }
}

