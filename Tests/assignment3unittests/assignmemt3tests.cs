using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using Assignment3;

namespace Assignment3.Tests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void BookConstructor_ShouldInitializeProperties()
        {
            // Arrange
            string expectedTitle = "The Great Gatsby";
            string expectedAuthor = "F. Scott Fitzgerald";
            string expectedISBN = "9780743273565";

            // Act
            Book book = new Book(expectedTitle, expectedAuthor, expectedISBN);

            // Assert
            Assert.That(book.Title, Is.EqualTo(expectedTitle));
            Assert.That(book.Author, Is.EqualTo(expectedAuthor));
            Assert.That(book.ISBN, Is.EqualTo(expectedISBN));
        }

        [Test]
        public void ToString_ShouldReturnFormattedString()
        {
            // Arrange
            string title = "1984";
            string author = "George Orwell";
            string isbn = "9780451524935";
            Book book = new Book(title, author, isbn);
            string expectedString = "Book Title: 1984, Author: George Orwell, ISBN: 9780451524935";

            // Act
            string result = book.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expectedString));
        }
    }

    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void DisplayAllBooks_ShouldPrintAllBooks()
        {
            // Arrange
            var books = new Dictionary<string, Book>
            {
                { "12345", new Book("The Great Gatsby", "F. Scott Fitzgerald", "12345") },
                { "67890", new Book("1984", "George Orwell", "67890") }
            };
            var program = new Program();
            var expectedOutput = "Book Title: The Great Gatsby, Author: F. Scott Fitzgerald, ISBN: 12345\n" +
                                 "Book Title: 1984, Author: George Orwell, ISBN: 67890\n";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                program.DisplayAllBooks(books);

                // Assert
                var result = sw.ToString().Replace("\r\n", "\n");
                Assert.That(result, Is.EqualTo(expectedOutput));
            }
        }

        [Test]
        public void DisplayBook_ShouldPrintBookDetails_WhenBookExists()
        {
            // Arrange
            var books = new Dictionary<string, Book>
            {
                { "12345", new Book("The Great Gatsby", "F. Scott Fitzgerald", "12345") }
            };
            var program = new Program();
            var expectedOutput = "Book Title: The Great Gatsby, Author: F. Scott Fitzgerald, ISBN: 12345\n";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                program.DisplayBook(books, "12345");

                // Assert
                var result = sw.ToString().Replace("\r\n", "\n");
                Assert.That(result, Is.EqualTo(expectedOutput));
            }
        }

        [Test]
        public void DisplayBook_ShouldPrintBookNotFound_WhenBookDoesNotExist()
        {
            // Arrange
            var books = new Dictionary<string, Book>();
            var program = new Program();
            var expectedOutput = "Book not found.\n";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                program.DisplayBook(books, "12345");

                // Assert
                var result = sw.ToString().Replace("\r\n", "\n");
                Assert.That(result, Is.EqualTo(expectedOutput));
            }
        }
    }
}



