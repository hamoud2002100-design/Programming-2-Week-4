using Assignment3;
using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Start();
    }

    public void Start()
    {
        Dictionary<string, Book> books = new Dictionary<string, Book>
        {
            { "978-9389647747", new Book("1984", "George Orwell", "978-9389647747") },
            { "978-0743273565", new Book("The Great Gatsby", "F. Scott Fitzgerald", "978-0743273565") },
            { "978-1430219491", new Book("Coders at Work", "Peter Seibel", "978-1430219491") }
        };

       
        DisplayAllBooks(books);

        
        Console.Write("Enter ISBN: ");
        string isbn = Console.ReadLine();

        
        DisplayBook(books, isbn);
    }

    public void DisplayAllBooks(Dictionary<string, Book> books)
    {
        foreach (var book in books.Values)
        {
            Console.WriteLine(book);
        }
    }

    public void DisplayBook(Dictionary<string, Book> books, string isbn)
    {
        if (books.ContainsKey(isbn))
        {
            Console.WriteLine(books[isbn]);
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }
}

