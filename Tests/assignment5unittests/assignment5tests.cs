namespace Assignment5to7.Tests
{
    [TestFixture]
    public class LibraryItemTests
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
            Assert.That(book.IsBorrowed, Is.False);
        }

        [Test]
        public void BookBorrow_ShouldSetIsBorrowedToTrue()
        {
            // Arrange
            Book book = new Book("1984", "George Orwell", "9780451524935");

            // Act
            book.Borrow();

            // Assert
            Assert.That(book.IsBorrowed, Is.True);
        }

        [Test]
        public void BookReturn_ShouldSetIsBorrowedToFalse()
        {
            // Arrange
            Book book = new Book("1984", "George Orwell", "9780451524935");
            book.Borrow(); // Set IsBorrowed to true first

            // Act
            book.Return();

            // Assert
            Assert.That(book.IsBorrowed, Is.False);
        }

        [Test]
        public void MagazineConstructor_ShouldInitializeProperties()
        {
            // Arrange
            string expectedTitle = "National Geographic";
            string expectedAuthor = "Various";
            string expectedISBN = "9781426217786";

            // Act
            Magazine magazine = new Magazine(expectedTitle, expectedAuthor, expectedISBN);

            // Assert
            Assert.That(magazine.Title, Is.EqualTo(expectedTitle));
            Assert.That(magazine.Author, Is.EqualTo(expectedAuthor));
            Assert.That(magazine.ISBN, Is.EqualTo(expectedISBN));
            Assert.That(magazine.IsBorrowed, Is.False);
        }

        [Test]
        public void MagazineBorrow_ShouldSetIsBorrowedToTrue()
        {
            // Arrange
            Magazine magazine = new Magazine("Time", "Various", "9781618931603");

            // Act
            magazine.Borrow();

            // Assert
            Assert.That(magazine.IsBorrowed, Is.True);
        }

        [Test]
        public void MagazineReturn_ShouldSetIsBorrowedToFalse()
        {
            // Arrange
            Magazine magazine = new Magazine("Time", "Various", "9781618931603");
            magazine.Borrow(); // Set IsBorrowed to true first

            // Act
            magazine.Return();

            // Assert
            Assert.That(magazine.IsBorrowed, Is.False);
        }
    }

    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void DisplayAllLibraryItems_ShouldPrintAllLibraryItems()
        {
            // Arrange
            var libraryItems = new Dictionary<string, LibraryItem>
            {
                { "book1", new Book("The Great Gatsby", "F. Scott Fitzgerald", "12345") },
                { "book2", new Book("The Godfather", "Francis Ford Coppola", "12346") },
                { "magazine1", new Magazine("Time", "Various", "9781618931603") }
            };
            var program = new Program();
            var expectedOutput = "Title: The Great Gatsby, Author: F. Scott Fitzgerald, ISBN: 12345, Borrowed: False\n" +
                                 "Title: The Godfather, Author: Francis Ford Coppola, ISBN: 12346, Borrowed: False\n" +
                                 "Title: Time, Author: Various, ISBN: 9781618931603, Borrowed: False\n";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                program.DisplayLibraryItems(libraryItems);

                // Assert
                var result = sw.ToString().Replace("\r\n", "\n");
                Assert.That(result, Is.EqualTo(expectedOutput));
            }
        }
    }
}